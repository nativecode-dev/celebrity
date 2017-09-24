namespace Celebrity.Core.Types
{
    using System;

    /// <summary>
    ///     Provides a string-like type to translate keys.
    /// </summary>
    [Serializable]
    public class EmailAddress : IEquatable<EmailAddress>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="value">String value for the login.</param>
        public EmailAddress(string value)
        {
            this.Raw = value;

            var parts = value.Split('@');
            this.AccountDomain = parts[1];
            this.AccountName = parts[0];
        }

        public string AccountName { get; }

        public string AccountDomain { get; }

        /// <summary>
        ///     Gets or sets the raw, non-translated value.
        /// </summary>
        public string Raw { get; }

        /// <summary>
        ///     Operator overload for equality.
        /// </summary>
        /// <param name="left">Left <see cref="EmailAddress" />.</param>
        /// <param name="right">Right <see cref="EmailAddress" />.</param>
        /// <returns>Returns true if the value properties are equal.</returns>
        public static bool operator ==(EmailAddress left, EmailAddress right)
        {
            var leftValue = object.ReferenceEquals(null, left) ? null : left.Raw;
            var rightValue = object.ReferenceEquals(null, right) ? null : right.Raw;

            return string.Equals(leftValue, rightValue);
        }

        /// <summary>
        ///     Operator overload for inequality.
        /// </summary>
        /// <param name="left">Left <see cref="EmailAddress" />.</param>
        /// <param name="right">Right <see cref="EmailAddress" />.</param>
        /// <returns>Returns true if the value properties are not equal.</returns>
        public static bool operator !=(EmailAddress left, EmailAddress right)
        {
            var leftValue = object.ReferenceEquals(null, left) ? null : left.Raw;
            var rightValue = object.ReferenceEquals(null, right) ? null : right.Raw;

            return !string.Equals(leftValue, rightValue);
        }

        /// <summary>
        ///     Implicit type conversion to string.
        /// </summary>
        /// <param name="instance">Instance of an existing <see cref="EmailAddress" />.</param>
        /// <returns>Key property or null.</returns>
        public static implicit operator string(EmailAddress instance)
        {
            return object.Equals(instance, null) ? null : instance.Raw;
        }

        /// <summary>
        ///     Implicit type conversion from string.
        /// </summary>
        /// <param name="value">Key of the login string.</param>
        /// <returns><see cref="EmailAddress" /> with the Key property set to the parameter.</returns>
        public static implicit operator EmailAddress(string value)
        {
            return new EmailAddress(value);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="T:System.Object" /> is equal to the current
        ///     <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((EmailAddress) obj);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(EmailAddress other)
        {
            return this == other;
        }

        /// <summary>
        ///     Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Raw != null ? this.Raw.GetHashCode() : 0;
        }
    }
}