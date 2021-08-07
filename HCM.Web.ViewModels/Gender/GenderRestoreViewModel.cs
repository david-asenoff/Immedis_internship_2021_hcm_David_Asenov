namespace HCM.Web.ViewModels.Gender
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GenderRestoreViewModel : GenderViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
