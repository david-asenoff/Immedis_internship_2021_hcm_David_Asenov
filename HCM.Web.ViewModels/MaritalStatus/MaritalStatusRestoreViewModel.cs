using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusRestoreViewModel : MaritalStatusViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
