namespace SEESALoginFinal.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString();
        List<T> LoadData<T, U>(string storedProcedure, U parameters);
        void RunStoredProcedure<T>(string storedProcedure, T parameters);
    }
}