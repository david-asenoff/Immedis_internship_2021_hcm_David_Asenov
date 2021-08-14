using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Gender
{
    public class GenderRestoreViewModel : GenderViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
