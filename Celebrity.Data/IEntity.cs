namespace Celebrity.Data
{
    using System;

    public interface IEntity
    {
        DateTimeOffset? DateCreated { get; set; }

        DateTimeOffset? DateModified { get; set; }

        string UserCreated { get; set; }

        string UserModified { get; set; }
    }

    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}