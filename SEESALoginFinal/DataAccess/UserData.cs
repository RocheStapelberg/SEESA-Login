using SEESALoginFinal.Models;

namespace SEESALoginFinal.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<UserModel> GetAllUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("sp_GetAllUsers", new { });
            return output;
        }

        public List<UserModel> GetUserById(int id)
        {
            var output = _sql.LoadData<UserModel, dynamic>("sp_GetUserById", new { id });
            return output;
        }

        public List<UserModel> GetUserByEmail(string email)
        {
            var output = _sql.LoadData<UserModel, dynamic>("sp_GetUserByEmail", new { email });
            return output;
        }

        public void InsertUser(UserModel user)
        {
            _sql.RunStoredProcedure("sp_InsertUser", user);
        }

        public void DeleteUser(int id)
        {
            _sql.RunStoredProcedure("sp_DeleteUser", new { id });
        }

        public void UpdateUser(UserModel user)
        {
            _sql.RunStoredProcedure("sp_UpdateUser", user);
        }
    }
}
