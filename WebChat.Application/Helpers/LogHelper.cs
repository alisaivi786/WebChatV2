namespace WebChat.Application.Helpers;

public static class LogHelper
{
    private static object lockHelper = new object();

    /// <summary>
    /// 根据枚举写日志通用（最新推荐使用）
    /// </summary>
    /// <param name="logContent">日志内容</param>
    /// <param name="ex">异常信息</param>
    /// <param name="logPath">日志目录枚举类型  </param>
    /// <param name="logFile">日志文件枚举类型 </param>
    /// <param name="isHourSplit">是否按照小时对日志分片 </param>

    public static void Write(string logContent, Exception ex = null, LogPathEnum logPath = LogPathEnum.Null, LogFileEnum logFile = LogFileEnum.info, bool isHourSplit = false)
    {
        string logFileName = "";
        if (isHourSplit)
        {
            logFileName = logFile.GetDescription() + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ".log";
        }
        else
        {
            logFileName = logFile.GetDescription() + ".log";
        }

        logContent += ex.IsEmpty() ? "" : $"{Environment.NewLine}ex：{GetExceptionMessage(ex)}";
        logContent = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}{logContent}";
        _Write(logPath.GetDescription(), logFileName, logContent);
    }

    /// <summary>
    /// 根据枚举写异常日志通用（最新推荐使用）
    /// </summary>
    /// <param name="logContent">日志内容</param>
    /// <param name="ex">异常信息</param>
    /// <param name="logPath">日志目录枚举类型  </param>
    /// <param name="logFile">日志文件枚举类型 </param>

    public static void WriteError(Exception ex = null, string logContent = "", LogPathEnum logPath = LogPathEnum.Null, LogFileEnum logFile = LogFileEnum.error)
    {
        if (ex.IsEmpty()) return;
        string logFileName = logFile.GetDescription() + ".log";
        var errorMsg = $"ex：{GetExceptionMessage(ex)}";
        if (!logContent.IsEmpty())
        {
            errorMsg = logContent + $"{Environment.NewLine}" + errorMsg;
        }
        errorMsg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}{errorMsg}";
        _Write(logPath.GetDescription(), logFileName, errorMsg);
    }

    /// <summary>
    /// 根据枚举写日志通用（扩展方法）
    /// </summary>
    /// <param name="logContent">日志内容 自动附加时间</param>
    /// <param name="ex">异常 Exception</param>
    /// <param name="logPath">日志目录枚举类型  </param>
    /// <param name="isHourSplit">是否按照小时对日志分片 </param>
    public static void WriteLog(this LogFileEnum logFile, string logContent, Exception ex = null, LogPathEnum logPath = LogPathEnum.Null, bool isHourSplit = false)
    {
        logContent += ex.IsEmpty() ? "" : $"{Environment.NewLine}ex：{GetExceptionMessage(ex)}";
        Write(logContent, ex, logPath, logFile: logFile, isHourSplit: isHourSplit);
    }


    /// <summary>
    /// 根据自定义路径写日志（扩展方法）
    /// </summary>
    /// <param name="logContent">日志内容 自动附加时间</param>
    /// <param name="logPath">日志路径  </param>
    /// <param name="ex">异常 Exception</param>
    /// <param name="isHourSplit">是否按照小时对日志分片 </param>
    public static void WriteLog(this LogFileEnum logFile, string logContent, string logPath, Exception ex = null, bool isHourSplit = false)
    {
        string logFileName = "";
        if (isHourSplit)
        {
            logFileName = logFile.GetDescription() + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ".log";
        }
        else
        {
            logFileName = logFile.GetDescription() + ".log";
        }
        logContent += ex.IsEmpty() ? "" : $"{Environment.NewLine}ex：{GetExceptionMessage(ex)}";
        logContent = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}{logContent}";
        _Write(logPath, logFileName, logContent);
    }

    /// <summary>
    /// 写日志底层方法
    /// </summary>
    /// <param name="logPath">日志目录</param>
    /// <param name="logFileName">日志文件名</param>
    /// <param name="logContent">日志内容 （自动附加时间）</param>
    private static void _Write(string logPath, string logFileName, string logContent)
    {
        if (string.IsNullOrWhiteSpace(logContent))
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(logPath))
        {
            logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", $"{DateTime.Now.ToString("yyyy-MM-dd")}");
        }
        else
        {
            logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", $"{DateTime.Now.ToString("yyyy-MM-dd")}", logPath.Trim('\\'));
        }
        if (string.IsNullOrWhiteSpace(logFileName))
        {
            logFileName = $"info.log";
        }

        if (!Directory.Exists(logPath))
        {
            Directory.CreateDirectory(logPath);
        }
        string fileName = Path.Combine(logPath, logFileName);
        Action taskAction = () =>
        {
            lock (lockHelper)
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(logContent + Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                }
            }
        };
        Task task = new Task(taskAction);
        task.Start();
    }

    private static string GetExceptionMessage(Exception ex)
    {
        string message = string.Empty;
        if (ex != null)
        {
            message += ex.Message;
            message += Environment.NewLine;
            Exception originalException = ex.GetOriginalException();
            if (originalException != null)
            {
                if (originalException.Message != ex.Message)
                {
                    message += originalException.Message;
                    message += Environment.NewLine;
                }
            }
            message += ex.StackTrace;
            message += Environment.NewLine;
        }
        return message;
    }
}
