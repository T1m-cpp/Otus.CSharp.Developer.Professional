namespace Reflection.Interfaces
{
    public interface ISerialize<T> where T : class
    {
        public string Serialize(T obj);
    }
}
