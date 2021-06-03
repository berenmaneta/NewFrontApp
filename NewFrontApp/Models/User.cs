namespace NewFrontApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordCheck { get; set; }

        public int IdProfile { get; set; }

        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Phone { get; set; }
    }
}
