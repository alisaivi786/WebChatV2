using System.Data.SqlClient;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebChat.Presistence.Ado;

public class AdoNetDatabase<T> : IDisposable where T : new()
{
    private readonly string? connectionString;
    private SqlConnection connection;

    public AdoNetDatabase(IAppSettings appSettings)
    {
        this.connectionString = appSettings.SqlConnectionString?? throw new ArgumentNullException("Sql Server Database Connection is Null");
        this.connection = new SqlConnection(connectionString);
        this.connection.Open();
    }

    public void InsertData(string tableName, params SqlParameter[] parameters)
    {
        string parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
        string parameterValues = string.Join(", ", parameters.Select(p => $"@{p.ParameterName}"));

        using SqlCommand command = new(
            @$"
            INSERT INTO {tableName} 
            ({parameterNames}) 
            VALUES ({parameterValues})", connection);
        command.Parameters.AddRange(parameters);
        command.ExecuteNonQuery();
    }

    public void UpdateData(string tableName, int entityId, params SqlParameter[] parameters)
    {
        string setClause = string.Join(", ", parameters.Select(p => $"{p.ParameterName}=@{p.ParameterName}"));
        using SqlCommand command = new($"UPDATE {tableName} SET {setClause} WHERE id=@EntityId", connection);
        command.Parameters.AddWithValue("@EntityId", entityId);
        command.Parameters.AddRange(parameters);
        command.ExecuteNonQuery();
    }

    public List<T> SelectData(string tableName, params SqlParameter[] parameters)
    {
        List<T> data = [];

        string query = @$"SELECT * FROM {tableName} ORDER BY id";
        if (parameters.Length > 0)
        {
            query += " WHERE " + string.Join(" AND ", parameters.Select(p => $"{p.ParameterName} = @{p.ParameterName}"));
        }

        using (SqlCommand command = new(query, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                T instance = new();
                MapDataReaderToEntity(reader, instance);
                data.Add(instance);
            }
        }

        return data;
    }

    public List<T> SelectData(string tableName, string[] selectedColumns = null, params object[] filters)
    {
        List<T> data = [];

        string columnList = (selectedColumns != null && selectedColumns.Length > 0)
            ? string.Join(", ", selectedColumns)
            : "*";

        string query = @$"SELECT {columnList} FROM {tableName}";

        if (filters != null && filters.Length > 0)
        {
            query += " WHERE ";

            List<string> filterConditions = [];

            for (int i = 0; i < filters.Length; i++)
            {
                if (filters[i] is SqlParameter parameter)
                {
                    filterConditions.Add($"{parameter.ParameterName} = @{parameter.ParameterName}");
                }
                else if (filters[i] is List<int> ids)
                {
                    filterConditions.Add($"UserId IN ({string.Join(", ", ids)})");
                }
                else
                {
                    throw new ArgumentException($"Unsupported filter type: {filters[i]?.GetType().Name}");
                }
            }

            query += string.Join(" AND ", filterConditions);
        }

        query += " ORDER BY UserId";

        using (SqlCommand command = new (query, connection))
        {
            foreach (var filter in filters.OfType<SqlParameter>())
            {
                command.Parameters.AddWithValue(filter.ParameterName, filter.Value);
            }

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                T instance = new();
                MapDataReaderToEntity(reader, instance);
                data.Add(instance);
            }
        }

        return data;
    }



    public List<T> SelectPageData(string tableName, int pageSize, int pageNumber)
    {
        int startRowIndex = (pageNumber - 1) * pageSize;
        List<T> data = [];

        using (SqlCommand command = new(@$"
            SELECT * FROM {tableName} 
            ORDER BY id 
            OFFSET {startRowIndex} 
            ROWS FETCH NEXT {pageSize} 
            ROWS ONLY", connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                T instance = new();
                MapDataReaderToEntity(reader, instance);
                data.Add(instance);
            }
        }

        return data;
    }

    internal static void MapDataReaderToEntity(SqlDataReader reader, T entity)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var propertyName = reader.GetName(i);
            var property = typeof(T).GetProperty(propertyName);

            if (property != null && property.CanWrite)
            {
                var value = reader[i];
                if (value != DBNull.Value)
                {
                    property.SetValue(entity, value);
                }
            }
        }
    }

    public T GetSingleRow<T>(string tableName, string[] columnNames, string whereCondition = "1=1") where T : new()
    {
        // Build the SQL query
        string columns = string.Join(", ", columnNames);
        string query = $"SELECT {columns} FROM {tableName} WHERE {whereCondition}";

        // Initialize the result variable of type T
        T result = new();

        using (SqlCommand command = new(query, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            // Check if there are rows
            if (reader.Read())
            {
                // Map each column to the corresponding property of T
                for (int i = 0; i < columnNames.Length; i++)
                {
                    string columnName = columnNames[i];
                    object columnValue = reader[columnName];

                    // Get PropertyInfo for the current property
                    PropertyInfo propertyInfo = typeof(T).GetProperty(columnName);

                    if (propertyInfo != null)
                    {
                        if (columnValue == DBNull.Value)
                        {
                            // Handle DBNull value, set default values or handle as needed
                            propertyInfo.SetValue(result, null);
                        }
                        else
                        {
                            // Handle value type conversion (e.g., int to string)
                            propertyInfo.SetValue(result, Convert.ChangeType(columnValue, propertyInfo.PropertyType));
                        }
                    }
                }
            }
        }

        return result;
    }

    public List<T> GetRows<T>(string tableName, string[] columnNames, string whereCondition = "1=1") where T : new()
    {
        // Build the SQL query
        string columns = string.Join(", ", columnNames);
        string query = $"SELECT {columns} FROM {tableName} WHERE {whereCondition}";

        // Initialize the result variable as a list of type T
        List<T> results = [];

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            // Check if there are rows
            while (reader.Read())
            {
                // Create a new instance of T for each row
                T result = new ();

                // Map each column to the corresponding property of T
                for (int i = 0; i < columnNames.Length; i++)
                {
                    string columnName = columnNames[i];
                    object columnValue = reader[columnName];

                    // Get PropertyInfo for the current property
                    PropertyInfo propertyInfo = typeof(T).GetProperty(columnName);

                    if (propertyInfo != null)
                    {
                        if (columnValue == DBNull.Value)
                        {
                            // Handle DBNull value, set default values or handle as needed
                            propertyInfo.SetValue(result, null);
                        }
                        else
                        {
                            // Handle value type conversion (e.g., int to string)
                            propertyInfo.SetValue(result, Convert.ChangeType(columnValue, propertyInfo.PropertyType));
                        }
                    }
                }

                // Add the populated instance to the results list
                results.Add(result);
            }
        }

        return results;
    }



    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
        }
    }

    ~AdoNetDatabase()
    {
        Dispose(false);
    }
}
