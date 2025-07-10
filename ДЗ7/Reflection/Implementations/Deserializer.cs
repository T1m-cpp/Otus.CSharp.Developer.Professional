using Reflection.Interfaces;
using System.Reflection;

public class Deserializer<T> : IDeserialize<T> where T : class, new()
{
    public T Deserialize(string csv)
    {
        if (string.IsNullOrEmpty(csv)) throw new ArgumentNullException(nameof(csv));

        var pairs = csv.Split(';', StringSplitOptions.RemoveEmptyEntries)
                      .Select(p => p.Trim())
                      .Where(p => p.Contains(':'));
        var obj = new T();
        var fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var pair in pairs)
        {
            var parts = pair.Split(':');
            if (parts.Length != 2) continue;

            var fieldName = parts[0].Trim();
            var valueStr = parts[1].Trim();

            var field = fields.FirstOrDefault(f => f.Name == fieldName);
            if (field == null) continue;

            try
            {
                object value = ParseValue(valueStr, field.FieldType);
                if (value != null)
                {
                    field.SetValue(obj, value);
                }
            }
            catch (FormatException)
            {
                // Пропускаем, если значение не удалось распарсить
                continue;
            }
        }

        return obj;
    }
    private object ParseValue(string valueStr, Type targetType)
    {
        if (string.IsNullOrEmpty(valueStr)) return null;

        return targetType switch
        {
            Type t when t == typeof(int) => int.TryParse(valueStr, out var result) ? result : throw new FormatException($"Cannot parse '{valueStr}' to int"),
            Type t when t == typeof(string) => valueStr,
            Type t when t == typeof(double) => double.TryParse(valueStr, System.Globalization.CultureInfo.InvariantCulture, out var result) ? result : throw new FormatException($"Cannot parse '{valueStr}' to double"),
            Type t when t == typeof(float) => float.TryParse(valueStr, System.Globalization.CultureInfo.InvariantCulture, out var result) ? result : throw new FormatException($"Cannot parse '{valueStr}' to float"),
            Type t when t == typeof(bool) => bool.TryParse(valueStr, out var result) ? result : throw new FormatException($"Cannot parse '{valueStr}' to bool"),
            Type t when t == typeof(DateTime) => DateTime.TryParse(valueStr, System.Globalization.CultureInfo.InvariantCulture, out var result) ? result : throw new FormatException($"Cannot parse '{valueStr}' to DateTime"),
            _ => throw new FormatException($"Unsupported type {targetType.Name}")
        };
    }
}
