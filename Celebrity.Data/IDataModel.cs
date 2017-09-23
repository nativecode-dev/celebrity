namespace Celebrity.Data
{
    using System;

    public interface IDataModel
    {
        DateTimeOffset DateCreated { get; set; }

        DateTimeOffset DateModified { get; set; }

        string UserCreated { get; set; }

        string UserModified { get; set; }
    }

    public interface IDataModel<TKey> : IDataModel where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}