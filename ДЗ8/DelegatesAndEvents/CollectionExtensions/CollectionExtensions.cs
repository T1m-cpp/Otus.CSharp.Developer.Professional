namespace DelegatesAndEvents.CollectionExtensions
{
    internal static class CollectionExtensions
    {
        internal static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            
            if (!collection.Any()) throw new InvalidOperationException("Collection is empty");

            float maxValue = float.MinValue;
            T maxItem = null;

            foreach (var item in collection)
            {
                float value = convertToNumber(item);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxItem = item;
                }
            }
            return maxItem;
        }
    }
}
