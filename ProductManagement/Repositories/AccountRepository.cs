using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember? GetAccountByEmail(string email)
            => AccountDAO.Instance.GetAccountByEmail(email);

        public AccountMember? Login(string email, string password)
            => AccountDAO.Instance.Login(email, password);
    }
}
