using System.ComponentModel.DataAnnotations;

namespace RepositoryT.EntityFramework.SimpleBusiness.Entities
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}