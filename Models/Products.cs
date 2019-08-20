using System.ComponentModel.DataAnnotations;

namespace ZabudApi.Models
{
    public  class Products
    {
        [Key]
        public int ID{get;set;}

        [Required]
        public float Price {get;set;}
        [Required]
        public string name {get; set;}
        [Required]
        public int stock {get;set;}
    }
}