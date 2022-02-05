using System;

namespace Cascade.Challenges.Books.Mvc.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="!:https://owl.purdue.edu/owl/research_and_citation/mla_style/mla_formatting_and_style_guide/mla_formatting_and_style_guide.html"/>
    public class MlaBookCitationFormatProvider : BookCitationFormatProvider
    {
        /// <inheritdoc/>
        public MlaBookCitationFormatProvider()
            : base()
        {
        }

        /// <inheritdoc/>
        private MlaBookCitationFormatProvider(MlaBookCitationFormatProvider other)
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

        public override object Clone() => new MlaBookCitationFormatProvider(this);
    }
}
