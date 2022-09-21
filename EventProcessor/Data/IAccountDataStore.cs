using EventProcessor.Types;

namespace EventProcessor.Stores
{
    public interface IAccountDataStore
    {
        Account GetAccount(int Id);
        void UpdateAccount(Account account);
    }
}