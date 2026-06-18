using BusinessObjects;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public AccountMember? Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;
            return _accountRepository.Login(email, password);
        }

        public AccountMember? GetAccountByEmail(string email)
            => _accountRepository.GetAccountByEmail(email);
    }
}
