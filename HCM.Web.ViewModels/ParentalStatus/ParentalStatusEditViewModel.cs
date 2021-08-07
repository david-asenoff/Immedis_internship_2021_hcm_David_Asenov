using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusEditViewModel : ParentalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
