namespace API.Service
{
    public interface ICacheService
    {
        object Get(string key);

        void Set(string key, object content);

        void Remove(string key);
    }
}
