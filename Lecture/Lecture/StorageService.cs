namespace Lecture
{
    public class StorageService
    {
        public StorageService(IStore store)
        {
            Store=store;
        }

        public IStore Store { get; }

        public void Save(object item)
        {
            if (item is InMemoryStore store)
            {

            }
            else if (item is DiskStore disk)
            {

            }
            else
            {
                throw new ArgumentException(nameof(item));
            }
        }
    }
}