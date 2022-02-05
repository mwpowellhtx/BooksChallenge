using System;

namespace Cascade.Challenges.Books.Mvc.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="!:https://owl.purdue.edu/owl/research_and_citation/chicago_manual_17th_edition/cmos_formatting_and_style_guide/books.html"/>
    public class ChicagoBookCitationFormatProvider : BookCitationFormatProvider
    {
        /// <inheritdoc/>
        public ChicagoBookCitationFormatProvider()
            : base()
        {
        }

        /// <inheritdoc/>
        private ChicagoBookCitationFormatProvider(ChicagoBookCitationFormatProvider other)
            : base(other)
        {
        }

        /// <inheritdoc/>
        public override string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg is Book book)
            {
                // TODO: TBD: starting with a simple base case...
                // TODO: TBD: we may elaborate to include journal, magazine articles
                return $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.Title}. {book.Publisher}, {book.PublishedOn.Year}.";
            }

            return base.Format(format, arg, provider);
        }

        public override object Clone() => new ChicagoBookCitationFormatProvider(this);
    }
}
