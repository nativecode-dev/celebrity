namespace Celebrity.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class DataModel : IDataModel
    {
        [DataType(DataType.DateTime)]
        public DateTimeOffset DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset DateModified { get; set; }

        [StringLength(128)]
        public string UserCreated { get; set; }

        [StringLength(128)]
        public string UserModified { get; set; }
    }

    public abstract class DataModel<TKey> : DataModel, IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}