namespace HCM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Marital status is the legally defined marital state.
    /// </summary>
    public class UserMaritalStatus : BaseDeletableModel<int>
    {
        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = GlobalConstants.MaritalStatusIsRequired)]
        [ForeignKey(nameof(MaritalStatus))]
        public int MaritalStatusId { get; set; }

        public virtual MaritalStatus MaritalStatus { get; set; }
    }
}