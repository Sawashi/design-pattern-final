using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace validation_framework_final
{
    // Class responsible for processing validations
    public class ValidationProcessor
    {
        private readonly List<IValidator> validators;

        public ValidationProcessor(List<IValidator> validators)
        {
            this.validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public bool ProcessValidation(object dataObject)
        {
            if (dataObject == null)
            {
                throw new ArgumentNullException(nameof(dataObject));
            }

            Type dataType = dataObject.GetType();
            PropertyInfo[] properties = dataType.GetProperties();

            foreach (var property in properties)
            {
                object propertyValue = property.GetValue(dataObject);

                // Perform validation based on property attributes
                if (property.IsDefined(typeof(ValidationAttribute), true))
                {
                    var validationAttribute = (ValidationAttribute)property.GetCustomAttribute(typeof(ValidationAttribute), true);
                    if (validationAttribute != null)
                    {
                        foreach (var validator in validators)
                        {
                            if (!validator.Validate(propertyValue.ToString()))
                            {
                                // Validation failed
                                Console.WriteLine($"Validation failed for property '{property.Name}': {propertyValue}");
                                return false;
                            }
                        }
                    }
                }
            }

            // All validations passed
            Console.WriteLine("All validations passed.");
            return true;
        }
    }

    // Attribute to mark properties that require validation
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class ValidationAttribute : Attribute
    {
        // You can add any properties or methods relevant to your validation attributes
    }
}
