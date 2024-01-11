using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    public interface IErrorMessageDecorator
    {
        string Decorate(List<string> errorMessages);
    }

    // Concrete decorator for formatting error messages with severity
    public class SeverityDecorator : IErrorMessageDecorator
    {
        public string Decorate(List<string> errorMessages)
        {
            // Apply severity formatting to error messages
            return $"[ERROR] {string.Join(" | ", errorMessages)}";
        }
    }

    // Concrete decorator for additional formatting
    public class FormatDecorator : IErrorMessageDecorator
    {
        public string Decorate(List<string> errorMessages)
        {
            // Apply additional formatting to error messages
            return $"*** {string.Join(Environment.NewLine, errorMessages)} ***";
        }
    }
}
