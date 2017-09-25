namespace Celebrity.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class Model : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(this, validationContext, results))
            {
                return results;
            }

            return results;
        }
    }
}