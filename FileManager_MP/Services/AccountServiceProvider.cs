

namespace FileManager_MP.Services
{
    public class AccountServiceProvider : IAccountServiceProvider
    {

        public int ChangeRole(string role)
        {
            switch (role.ToLower())
            {
                case "admin":
                    return 1;
                case "user":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}