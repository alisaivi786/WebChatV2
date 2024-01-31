#region NameSpace
namespace WebChat.Extension.AttributeHelper;
#endregion

#region EnumTypeAttribute
/// <summary>
/// EnumTypeAttribute
/// </summary>
/// <param name="startNum"></param>
[AttributeUsage(AttributeTargets.All)]
public class EnumTypeAttribute(int startNum) : Attribute
{
	public int StartNum { get; set; } = startNum;
}

#endregion