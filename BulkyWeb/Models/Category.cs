using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace BulkyWeb.Models
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        [DisplayName("Categor Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }   
    }
}
