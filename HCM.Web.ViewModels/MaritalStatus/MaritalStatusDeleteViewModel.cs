﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusDeleteViewModel : MaritalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}