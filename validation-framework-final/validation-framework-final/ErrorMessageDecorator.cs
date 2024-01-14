using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    // Base decorator interface for error message decoration
    public interface IErrorMessageDecorator
    {
        List<string> Decorate(List<string> errorMessages);
    }

    // Concrete decorator for severity formatting
    public class SeverityDecorator : IErrorMessageDecorator
    {
        private readonly IErrorMessageDecorator innerDecorator;

        public SeverityDecorator(IErrorMessageDecorator innerDecorator)
        {
            this.innerDecorator = innerDecorator;
        }

        public List<string> Decorate(List<string> errorMessages)
        {
            // Apply severity formatting to error messages
            List<string> decoratedMessages = new List<string> { $"[Decorated message] {string.Join(" | ", errorMessages)}" };
            return innerDecorator != null ? innerDecorator.Decorate(decoratedMessages) : decoratedMessages;
        }
    }

    // Concrete decorator for additional formatting
    public class FormatDecorator : IErrorMessageDecorator
    {
        private readonly IErrorMessageDecorator innerDecorator;

        public FormatDecorator(IErrorMessageDecorator innerDecorator)
        {
            this.innerDecorator = innerDecorator;
        }

        public List<string> Decorate(List<string> errorMessages)
        {
            // Apply additional formatting to error messages
            List<string> decoratedMessages = new List<string> { $"*** {string.Join(Environment.NewLine, errorMessages)} ***" };
            return innerDecorator != null ? innerDecorator.Decorate(decoratedMessages) : decoratedMessages;
        }
    }
}
