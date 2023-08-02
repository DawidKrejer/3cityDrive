namespace ASP_NET_REACT_CRUD_Project.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
