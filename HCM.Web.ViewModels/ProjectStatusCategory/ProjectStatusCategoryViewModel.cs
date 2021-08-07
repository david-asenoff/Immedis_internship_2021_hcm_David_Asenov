using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryViewModel : ProjectStatusCategoryViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
