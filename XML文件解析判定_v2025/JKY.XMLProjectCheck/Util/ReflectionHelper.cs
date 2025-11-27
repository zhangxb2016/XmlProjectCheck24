using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Linq;


namespace JKY.XMLProjectCheck.Util
{
    public class ReflectionHelper
    {
        public DataTable GetClassPropertiesFromDll(string dllPath)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Namespace", typeof(string));
            resultTable.Columns.Add("ClassName", typeof(string));
            resultTable.Columns.Add("AttName", typeof(string));
            resultTable.Columns.Add("DataType", typeof(string));

            try
            {
                // 使用LoadFile替代LoadFrom以避免绑定重定向问题
                Assembly assembly = Assembly.LoadFile(dllPath);

                // 处理ReflectionTypeLoadException
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    types = ex.Types.Where(t => t != null).ToArray();

                    // 将加载错误信息添加到结果表
                    resultTable.Columns.Add("LoadErrors", typeof(string));
                    foreach (Exception loaderEx in ex.LoaderExceptions)
                    {
                        resultTable.Rows.Add(
                            "加载错误",
                            "类型加载失败",
                            string.Empty,
                            string.Empty,
                            loaderEx?.Message ?? "未知加载错误");
                    }
                }

                foreach (Type type in types)
                {
                    if (type == null) continue; // 跳过加载失败的类型

                    if (type.IsClass)
                    {
                        string typeNamespace = type.Namespace ?? "[无命名空间]";

                        PropertyInfo[] properties;
                        try
                        {
                            properties = type.GetProperties(
                                BindingFlags.Public |
                                BindingFlags.Instance |
                                BindingFlags.DeclaredOnly);
                        }
                        catch (Exception ex)
                        {
                            // 添加属性加载错误信息
                            resultTable.Rows.Add(
                                typeNamespace,
                                type.Name,
                                "属性加载失败",
                                string.Empty,
                                ex.Message);
                            continue;
                        }

                        if (properties.Length == 0)
                        {
                            resultTable.Rows.Add(typeNamespace, type.Name, string.Empty, string.Empty);
                        }
                        else
                        {
                            foreach (PropertyInfo property in properties)
                            {
                                string dataType = GetFriendlyTypeName(property.PropertyType);
                                resultTable.Rows.Add(typeNamespace, type.Name, property.Name, dataType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultTable.Rows.Clear();
                resultTable.Columns.Clear();
                resultTable.Columns.Add("Error", typeof(string));
                resultTable.Rows.Add($"程序集加载失败: {ex.Message}");

                // 添加内部异常信息
                if (ex.InnerException != null)
                {
                    resultTable.Rows.Add($"内部错误: {ex.InnerException.Message}");
                }
            }

            return resultTable;
        }

        private string GetFriendlyTypeName(Type type)
        {
            if (type == null) return "[类型加载失败]";
            if (type == typeof(void)) return "void";
            if (type == typeof(object)) return "object";
            if (!type.IsGenericType) return GetNonGenericTypeName(type);

            // 处理可空类型
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return GetFriendlyTypeName(Nullable.GetUnderlyingType(type)) + "?";
            }

            StringBuilder sb = new StringBuilder();
            string typeName = type.Name.Split('`')[0];

            if (!string.IsNullOrEmpty(type.Namespace))
            {
                sb.Append(type.Namespace + ".");
            }

            sb.Append(typeName);
            sb.Append('<');

            Type[] genericArgs = type.GetGenericArguments();
            for (int i = 0; i < genericArgs.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(GetFriendlyTypeName(genericArgs[i]));
            }

            sb.Append('>');

            return sb.ToString();
        }

        private string GetNonGenericTypeName(Type type)
        {
            if (type == typeof(int)) return "int";
            if (type == typeof(string)) return "string";
            if (type == typeof(bool)) return "bool";
            if (type == typeof(decimal)) return "decimal";
            if (type == typeof(float)) return "float";
            if (type == typeof(double)) return "double";
            if (type == typeof(long)) return "long";
            if (type == typeof(short)) return "short";
            if (type == typeof(byte)) return "byte";
            if (type == typeof(char)) return "char";
            if (type == typeof(DateTime)) return "DateTime";

            if (type.IsArray)
            {
                int rank = type.GetArrayRank();
                string arrayNotation = rank > 1 ? $"[{new string(',', rank - 1)}]" : "[]";
                return GetFriendlyTypeName(type.GetElementType()) + arrayNotation;
            }

            return string.IsNullOrEmpty(type.Namespace)
                ? type.Name
                : $"{type.Namespace}.{type.Name}";
        }
    }
}
