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
        string Decorate(List<string> errorMessages);
    }

    // Concrete decorator for severity formatting
    public class SeverityDecorator : IErrorMessageDecorator
    {
        private readonly IErrorMessageDecorator wrappedDecorator;

        public SeverityDecorator(IErrorMessageDecorator wrappedDecorator)
        {
            this.wrappedDecorator = wrappedDecorator;
        }

        public string Decorate(List<string> errorMessages)
        {
            string decoratedMessages = $"[Result check] {string.Join(" | ", errorMessages)}";

            if (wrappedDecorator != null)
            {
                decoratedMessages = wrappedDecorator.Decorate(new List<string> { decoratedMessages });
            }

            return decoratedMessages;
        }
    }

    public class FormatDecorator : IErrorMessageDecorator
    {
        private readonly IErrorMessageDecorator wrappedDecorator;

        public FormatDecorator(IErrorMessageDecorator wrappedDecorator)
        {
            this.wrappedDecorator = wrappedDecorator;
        }

        public string Decorate(List<string> errorMessages)
        {
            string decoratedMessages = $"*** {string.Join(Environment.NewLine, errorMessages)} ***";

            if (wrappedDecorator != null)
            {
                decoratedMessages = wrappedDecorator.Decorate(new List<string> { decoratedMessages });
            }

            return decoratedMessages;
        }
    }
}
