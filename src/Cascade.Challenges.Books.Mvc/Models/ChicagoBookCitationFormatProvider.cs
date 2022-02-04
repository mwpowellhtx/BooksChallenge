using System;

namespace Cascade.Challenges.Books.Mvc.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="!:https://owl.purdue.edu/owl/research_and_citation/chicago_manual_17th_edition/cmos_formatting_and_style_guide/books.html"/>
    public class ChicagoBookCitationFormatProvider : ICloneable, IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        public ChicagoBookCitationFormatProvider()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        private ChicagoBookCitationFormatProvider(ChicagoBookCitationFormatProvider other)
        {
            // TODO: TBD: transfer/translate whatever values/props from Other...
        }

        /// <inheritdoc/>
        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        /// <inheritdoc/>
        /// <remarks>This provider is not designed to take a custom <paramref name="format"/> per se,
        /// since the citation style guide defines for us the format for internal use.</remarks>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is Book book)
            {
                // TODO: TBD: starting with a simple base case...
                // TODO: TBD: we may elaborate to include journal, magazine articles
                return $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.Title}. {book.Publisher}, {book.PublishedOn.Year}.";
            }

            return arg?.ToString()
                ?? throw new ArgumentNullException(nameof(arg), $"Expecting not null argument '{nameof(arg)}'")
                ;
        }

        public virtual object Clone() => new ChicagoBookCitationFormatProvider(this);
    }
}
