namespace Lecture.Tests
{
    public class StorageService
    {
        public StorageService(IStore store)
        {
            Store = store;
        }

        public IStore Store { get; }
    }
}