using System.ComponentModel.DataAnnotations;

namespace ShopBlazor.Api.Entities
{
    public class User
    {
        public long Id { get; set; }
        [Required, MaxLength(100)]
        public string NameUser { get; set; }= string.Empty;
        public Cart? Cart { get; set; } 
    }
}
