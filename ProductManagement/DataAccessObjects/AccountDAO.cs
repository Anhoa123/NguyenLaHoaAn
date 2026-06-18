using BusinessObjects;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        private static AccountDAO? _instance;
        public static AccountDAO Instance => _instance ??= new AccountDAO();

        private AccountDAO() { }

        public AccountMember? GetAccountByEmail(string email)
        {
            return MyStoreContext.Accounts
                .FirstOrDefault(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public AccountMember? Login(string email, string password)
        {
            return MyStoreContext.Accounts
                .FirstOrDefault(a =>
                    a.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    a.Password == password);
        }
    }
}
