<script runat="template">

  public string MemberShortType(ColumnSchema column)
  {
  if (column.Name.EndsWith("TypeCode")) return "Obj";

  switch (column.DataType)
  {
  case DbType.AnsiString: return "Str";
  case DbType.AnsiStringFixedLength: return "Str";
  case DbType.Boolean: return "Bln";
  case DbType.Currency: return "Int";
  case DbType.Decimal: return "Int";
  case DbType.Double: return "Dbl";
  case DbType.Int16: return "Int";
  case DbType.Int32: return "Int";
  case DbType.Int64: return "Lng";
  case DbType.Single: return "Dbl";
  case DbType.String: return "Str";
  case DbType.StringFixedLength: return "Str";
  case DbType.UInt16: return "Int";
  case DbType.UInt32: return "Int";
  case DbType.UInt64: return "Int";
  default:
  {
  return "Obj";
  }
  }
  }

  public string MemberType(ColumnSchema column)
  {
  if (column.Name.EndsWith("TypeCode")) return column.Name;

  switch (column.DataType)
  {
  case DbType.AnsiString: return "String";
  case DbType.AnsiStringFixedLength: return "String";
  case DbType.Binary: return "Byte()";
  case DbType.Boolean: return "Boolean";
  case DbType.Byte: return "Byte";
  case DbType.Currency: return "Decimal";
  case DbType.Date: return "Date";
  case DbType.DateTime: return "Date";
  case DbType.Decimal: return "Decimal";
  case DbType.Double: return "Double";
  case DbType.Guid: return "Guid";
  case DbType.Int16: return "Short";
  case DbType.Int32: return "Integer";
  case DbType.Int64: return "Long";
  case DbType.Object: return "Object";
  case DbType.SByte: return "SByte";
  case DbType.Single: return "Double";
  case DbType.String: return "String";
  case DbType.StringFixedLength: return "String";
  case DbType.Time: return "TimeSpan";
  case DbType.UInt16: return "UInt16";
  case DbType.UInt32: return "UInt32";
  case DbType.UInt64: return "UInt64";
  case DbType.VarNumeric: return "Decimal";
  default:
  {
  return "Object";
  }
  }
  }

  public string InitializeType(ColumnSchema column)
  {
  if (column.Name.EndsWith("TypeCode")) return "New "+column.Name;

  switch (column.DataType)
  {
  case DbType.AnsiString: return "String.Empty";
  case DbType.AnsiStringFixedLength: return "String.Empty";
  case DbType.Binary: return "Nothing";
  case DbType.Boolean: return "False";
  case DbType.Byte: return "0";
  case DbType.Currency: return "0";
  case DbType.Date: return "New Date";
  case DbType.DateTime: return "New Date";
  case DbType.Decimal: return "0";
  case DbType.Double: return "0";
  case DbType.Guid: return "0";
  case DbType.Int16: return "0";
  case DbType.Int32: return "0";
  case DbType.Int64: return "0";
  case DbType.Object: return "Nothing";
  case DbType.SByte: return "0";
  case DbType.Single: return "0";
  case DbType.String: return "String.Empty";
  case DbType.StringFixedLength: return "String.Empty";
  case DbType.Time: return "New TimeSpan";
  case DbType.UInt16: return "0";
  case DbType.UInt32: return "0";
  case DbType.UInt64: return "0";
  case DbType.VarNumeric: return "0";
  default:
  {
  return "Nothing";
  }
  }
  }

  public bool IsIntType(ColumnSchema column)
  {
  if (column.Name.EndsWith("TypeCode")) return false;

  switch (column.DataType)
  {
  case DbType.AnsiString: return false;
  case DbType.AnsiStringFixedLength: return false;
  case DbType.Binary: return false;
  case DbType.Boolean: return false;
  case DbType.Byte: return false;
  case DbType.Currency: return false;
  case DbType.Date: return false;
  case DbType.DateTime: return false;
  case DbType.Decimal: return true;
  case DbType.Double: return false;
  case DbType.Guid: return false;
  case DbType.Int16: return true;
  case DbType.Int32: return true;
  case DbType.Int64: return true;
  case DbType.Object: return false;
  case DbType.SByte: return false;
  case DbType.Single: return false;
  case DbType.String: return false;
  case DbType.StringFixedLength: return false;
  case DbType.Time: return false;
  case DbType.UInt16: return true;
  case DbType.UInt32: return true;
  case DbType.UInt64: return true;
  case DbType.VarNumeric: return false;
  default:
  {
  return false;
  }
  }
  }

  public string InsertMember(ColumnSchema column)
  {
  if (column.Name.EndsWith("TypeCode")) return "\"'\" & "+MemberName(column)+".ToString()"+" & \"'\"";

	switch (column.DataType)
	{
		case DbType.AnsiString: return "\"'\" & "+MemberName(column)+" & \"'\"";
		case DbType.AnsiStringFixedLength: return "\"'\" & "+MemberName(column);
		case DbType.Binary: return MemberName(column)+".ToString()";
		case DbType.Boolean: return MemberName(column)+".ToString()";
		case DbType.Byte: return MemberName(column)+".ToString()";
		case DbType.Currency: return MemberName(column)+".ToString()";
		case DbType.Date: return "\"'\" & "+MemberName(column)+".ToString(CONST_DATE_FORMAT)"+" & \"'\"";
		case DbType.DateTime: return "\"'\" & "+MemberName(column)+".ToString(CONST_DATE_TIME_FORMAT)"+" & \"'\"";
		case DbType.Decimal: return MemberName(column)+".ToString()";
		case DbType.Double: return MemberName(column)+".ToString()";
		case DbType.Guid: return MemberName(column)+".ToString()";
		case DbType.Int16: return MemberName(column)+".ToString()";
		case DbType.Int32: return MemberName(column)+".ToString()";
		case DbType.Int64: return MemberName(column)+".ToString()";
		case DbType.Object: return MemberName(column)+".ToString()";
		case DbType.SByte: return MemberName(column)+".ToString()";
		case DbType.Single: return MemberName(column)+".ToString()";
		case DbType.String: return "\"'\" & "+MemberName(column)+" & \"'\"";
		case DbType.StringFixedLength: return MemberName(column);
		case DbType.Time: return "\"'\" & "+MemberName(column)+".ToString(CONST_DATE_TIME_FORMAT)"+" & \"'\"";
		case DbType.UInt16: return MemberName(column)+".ToString()";
		case DbType.UInt32: return MemberName(column)+".ToString()";
		case DbType.UInt64: return MemberName(column)+".ToString()";
		case DbType.VarNumeric: return MemberName(column)+".ToString()";
		default:
		{
			return "\"'\" & "+MemberName(column)+".ToString()"+" & \"'\"";
		}
    }
}

public string MemberName(ColumnSchema column)
{
    return "m"+MemberShortType(column)+column.Name;
}

public string PropertyName(ColumnSchema column)
{
    return "mPrp"+column.Name;
}
</script>