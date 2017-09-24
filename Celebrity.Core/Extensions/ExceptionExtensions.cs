namespace Celebrity.Core.Extensions
{
    using System;
    using System.Text;

    public static class ExceptionExtensions
    {
        public static string ToExceptionString(this Exception exception, bool includeStackTrace = false)
        {
            return new StringBuilder().Exception(exception, includeStackTrace).ToString();
        }

        private static StringBuilder Exception(this StringBuilder builder, Exception exception, bool includeStackTrace)
        {
            builder.AppendLine(exception.Message);

            if (includeStackTrace)
            {
                builder.AppendLine(exception.StackTrace);
            }

            if (exception is AggregateException aggregate)
            {
                foreach (var inner in aggregate.InnerExceptions)
                {
                    builder.Exception(inner, includeStackTrace);
                }
            }
            else if (exception.InnerException != null)
            {
                builder.Exception(exception.InnerException, includeStackTrace);
            }

            return builder;
        }
    }
}