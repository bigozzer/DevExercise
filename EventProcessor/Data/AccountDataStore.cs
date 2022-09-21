using EventProcessor.Types;

namespace EventProcessor.Stores
{

    public class AccountDataStore : IAccountDataStore
    {
        //Fake in memory store
        private static List<Account> accounts = new List<Account>()
        {
            new Account(){Id = 1},
            new Account(){Id = 2}
        };


        public Account GetAccount(int id)
        {
            return accounts.Single(x => x.Id == id);
        }

        public void UpdateAccount(Account account)
        {
            //Not needed for example
        }

    }
}