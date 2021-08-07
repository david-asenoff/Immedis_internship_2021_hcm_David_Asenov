using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryRestoreViewModel : ProjectStatusCategoryViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }

    }
}
