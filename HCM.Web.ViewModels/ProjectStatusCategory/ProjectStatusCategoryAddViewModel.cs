using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryAddViewModel : ProjectStatusCategoryViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
