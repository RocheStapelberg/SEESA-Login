using SEESALoginFinal.Models;

namespace SEESALoginFinal.DataAccess
{
    public interface IUserData
    {
        void DeleteUser(int id);
        List<UserModel> GetAllUsers();
        List<UserModel> GetUserByEmail(string email);
        List<UserModel> GetUserById(int id);
        void InsertUser(UserModel user);
        void UpdateUser(UserModel user);
    }
}