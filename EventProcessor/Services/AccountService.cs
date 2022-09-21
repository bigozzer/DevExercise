using EventProcessor.Stores;
using EventProcessor.Types;

namespace EventProcessor.Services
{
    public class AccountService
    {
        public Account Get(int id)
        {
            var store = new AccountDataStore();
            var account = store.GetAccount(id);
            return account;
        }

        public void Save(Account account)
        {
            var store = new AccountDataStore();
            store.UpdateAccount(account);
        }

    }
}