using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DivVisualizer.Data
{
    internal static class EnumHelper
    {
        public static string GetDisplayName<T>(T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(nameof(value));
            }

            FieldInfo? fi = value
                    .GetType()
                    .GetField(value.ToString()!);

            if (fi == null)
                return "";

            DisplayAttribute[]? attributes = fi.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Name!;
            }

            return value.ToString()!;
        }

        public static T GetEnumFromString<T>(string value) where T : struct, IConvertible
        {
            foreach (T dataSource in Enum.GetValues(typeof(ImportDataSource)))
            {
                if (EnumHelper.GetDisplayName(dataSource).Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (T) dataSource;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
