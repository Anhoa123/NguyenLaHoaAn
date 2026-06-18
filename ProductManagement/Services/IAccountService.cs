using BusinessObjects;

namespace Services
{
    public interface IAccountService
    {
        AccountMember? Login(string email, string password);
        AccountMember? GetAccountByEmail(string email);
    }
}
