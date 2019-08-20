using System.ComponentModel.DataAnnotations;

namespace ZabudApi.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Document { get; set; }
        [Required]
        public string clientName { get; set; }
        [Required]
        public string clientLastName { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}