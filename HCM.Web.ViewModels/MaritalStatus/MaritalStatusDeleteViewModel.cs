﻿using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusDeleteViewModel : MaritalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
