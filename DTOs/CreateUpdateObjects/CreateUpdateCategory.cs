using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IcSMP_ApiApp.DTOs.CreateUpdateObjects
{
    public class CreateUpdateCategory
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        [Required]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Maximum number of characters is 50!")]
        public string Description { get; set; }
    }
}
 