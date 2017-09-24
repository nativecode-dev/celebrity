namespace Celebrity.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core;

    public abstract class Entity : IEntity
    {
        [DataType(DataType.DateTime)]
        public DateTimeOffset? DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DateModified { get; set; }

        [StringLength(CommonLengths.Email)]
        public string UserCreated { get; set; }

        [StringLength(CommonLengths.Email)]
        public string UserModified { get; set; }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}