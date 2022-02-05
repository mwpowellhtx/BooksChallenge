using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade.Challenges.Books.Mvc.Models
{
    /// <summary>
    /// Provides an abstract base class capturing the most common features of the Book Citation
    /// guidelines.
    /// </summary>
    public abstract class BookCitationFormatProvider : ICloneable, IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Default ctor.
        /// </summary>
        protected BookCitationFormatProvider()
        {
        }

        /// <summary>
        /// Copy ctor.
        /// </summary>
        /// <param name="other"></param>
        protected BookCitationFormatProvider(BookCitationFormatProvider other)
        {
            // TODO: TBD: transfer/translate whatever values/props from Other...
        }

        /// <inheritdoc/>
        public virtual object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        /// <inheritdoc/>
        /// <remarks>This provider is not designed to take a custom <paramref name="format"/>
        /// per se, since since the citation style guide defines for us the format for internal
        /// use. Whatever/ guidelines are to be enforced shall be options conveyed via the
        /// provider instance itself.</remarks>
        public virtual string Format(string format, object arg, IFormatProvider provider)
        {
            const string argName = nameof(arg);

            var bookType = typeof(Book);

            return arg?.ToString()
                ?? throw new ArgumentNullException(argName
                    , $"Expecting not null argument '{argName}' of type '${bookType.FullName}'"
                );
        }

        /// <inheritdoc/>
        public abstract object Clone();
    }
}
