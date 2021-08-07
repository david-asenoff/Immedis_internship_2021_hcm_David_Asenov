﻿using System;

namespace HCM.Web.ViewModels.Project
{
    public class ProjectViewModel : ProjectBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
