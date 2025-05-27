using System.ComponentModel.DataAnnotations;

namespace Task4_WebUsersAPI.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; } // Se detecta como Primary Key automaticamente si solo se llama Id
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Blocked { get; set; }
        public DateTime? Last_Connection {  get; set; }
    }
}
