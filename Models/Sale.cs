using System;
using System.ComponentModel.DataAnnotations;

namespace ZabudApi.Models
{
     public class Sale
    {
        [Key]
        public int ID {get;set;}
        [Required]
        public int client {get;set;}
        [Required]
        public DateTime dateSale {get;set;}

        [Required]
        public float totalPrice{get;set;}
    }
}