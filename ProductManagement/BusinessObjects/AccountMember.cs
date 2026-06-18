namespace BusinessObjects
{
    public class AccountMember
    {
        public int AccountId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int Role { get; set; } // 1 = Admin, 2 = Staff
    }
}
