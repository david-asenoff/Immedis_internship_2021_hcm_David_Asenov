namespace HCM.Data.Common
{
    using System;
    /// <summary>
    /// This abstract class may easily add usefull fields when inherited such us: bool IsDeleted, DateTime? DeletedOn, Id, DateTime CreatedOn and DateTime? ModifiedOn. Provides an easy way to keep deleted data in your database. "Soft delete" in database lingo means that you set a flag on an existing table which indicates that a record has been deleted, instead of actually deleting the record.
    /// </summary>
    /// <typeparam name="TKey">This param would define the type of the model Id</typeparam>
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
