﻿namespace Celebrity.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core;

    public abstract class DataModel : IDataModel
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

    public abstract class DataModel<TKey> : DataModel, IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}