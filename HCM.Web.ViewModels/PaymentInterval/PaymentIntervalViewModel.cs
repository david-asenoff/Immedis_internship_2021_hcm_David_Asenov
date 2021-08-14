using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalViewModel : PaymentIntervalViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
