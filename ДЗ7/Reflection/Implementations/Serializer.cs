using Reflection.Interfaces;

namespace Reflection.Implementations
{
    public class Serializer<T> : ISerialize<T> where T : class
    {
        public string Serialize(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var type = obj.GetType();
            var fields = type.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (!fields.Any()) return string.Empty;

            var values = fields.Select(f => $"{f.Name}: {f.GetValue(obj)?.ToString() ?? string.Empty}");
            return string.Join("; ", values);
        }
    }
}
