using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class StoreOwner
    {
        public int Id { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Store Owner ID must be have 2 characters")]
        public string SId { get; set; }
        [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
        [MaxLength(30, ErrorMessage = "Name should not exceed 30 characters.")]
        public string SName { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be have 10 digits.")]
        public string SPhone { get; set; }
        [Required]
        public char SGender { get; set; }
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters.")]
        [MaxLength(10, ErrorMessage = "Username should not exceed 10 characters.")]
        public string SUsername { get; set; }
        public string SAvatar { get; set; }
    }
}
