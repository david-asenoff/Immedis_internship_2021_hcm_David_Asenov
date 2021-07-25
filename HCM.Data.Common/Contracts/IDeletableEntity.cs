namespace HCM.Data.Common.Contracts
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
