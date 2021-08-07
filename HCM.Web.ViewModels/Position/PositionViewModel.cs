using System;
using System.Collections.Generic;
using System.Text;

namespace HCM.Web.ViewModels.Position
{
    public class PositionViewModel : PositionViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
