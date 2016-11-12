using System.ComponentModel.DataAnnotations;

namespace BSRBank.API.Models
{
    public class TransferModel
    {
        [Range(1,int.MaxValue)]
        [Required(ErrorMessage = "You need to provide amount to transfer")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "You need to provide source account number")]
        [MaxLength(26)]
        public string From { get; set; }
        [Required(ErrorMessage = "You need to provide title")]
        [MaxLength(500)]
        public string Title { get; set; }
    }
}
