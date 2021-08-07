using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusRestoreViewModel : MaritalStatusViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
