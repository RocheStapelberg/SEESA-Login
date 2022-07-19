namespace SEESALoginFinal.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
