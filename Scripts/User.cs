namespace ProjectManagementSystem.Scripts
{
    internal class User
    {
        public string Login { get; }
        public string Password { get; }
        public AccountType AccountType { get; }
        public User(string login, string password, AccountType accountType)
        {
            Login = login;
            Password = password;
            AccountType = accountType;
        }
    }

    public enum AccountType
    {
        User, Admin,
    }
}
