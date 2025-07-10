namespace Reflection.Interfaces
{
    public interface IDeserialize<T> where T : class
    {
        public T Deserialize(string csv);
    }
}
