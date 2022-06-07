namespace Lerato.CompositionRoot.Extensions
{
    public static class ObjectExtensions
    {
        // Check to determine if an object is null
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        // Check to determine if an object is not null   
        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }
    }
}
