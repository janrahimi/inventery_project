namespace InventoryManagementSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    public enum Role
    {
        Admin,
        Employee
    }
}
