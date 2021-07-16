﻿namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Position of employment means any position wherein a person is engaged for.
    /// </summary>
    public class Possition : BaseDeletableModel<string>
    {
        public Possition()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets name of the possition. It may be Senior Vice President, Chief People Officer, Executive Vice Presiden etc.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PossitionNameIsRequired)]
        public string Name { get; set; }
    }
}