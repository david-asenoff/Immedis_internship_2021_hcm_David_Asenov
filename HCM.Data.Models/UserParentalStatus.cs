namespace HCM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    /// <summary>
    /// Marital status is the legally defined marital state.
    /// </summary>
    public class UserParentalStatus : BaseDeletableModel<int>
    {
        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = GlobalConstants.ParentalStatusIsRequired)]
        [ForeignKey(nameof(ParentalStatus))]
        public int ParentalStatusId { get; set; }

        public virtual ParentalStatus ParentalStatus { get; set; }
    }
}