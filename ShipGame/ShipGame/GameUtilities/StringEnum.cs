using ShipGame.GameUtilities;
using System;
using System.Reflection;

public static class StringEnum
{
	public static string GetStringValue(Enum value)
	{
		string output = null;
		Type type = value.GetType();

		FieldInfo fi = type.GetField(value.ToString());
		StringValueAttribute[] attrs =
		   fi.GetCustomAttributes(typeof(StringValueAttribute),
							  false) as StringValueAttribute[];
		if (attrs.Length > 0)
		{
			output = attrs[0].Value;
		}

		return output;
	}
}