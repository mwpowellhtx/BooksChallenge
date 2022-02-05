using System;

namespace Cascade.Challenges.Books.Mvc.Models
{
    /// <summary>
    /// Represents the basic Book model to the sytem.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or Sets the BookID.
        /// </summary>
        public Guid BookID { get; set; }

        /// <summary>
        /// Gets or Sets the Publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or Sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the AddedOn date time.
        /// </summary>
        public DateTimeOffset AddedOn { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Gets or Sets the AuthorLastName.
        /// </summary>
        public string AuthorLastName { get; set; }

        /// <summary>
        /// Gets or Sets the AuthorFirstName.
        /// </summary>
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Gets or Sets the PublishedOn date time.
        /// </summary>
        public DateTimeOffset PublishedOn { get; set; }

        /// <summary>
        /// Gets or Sets the Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets the Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or Sets the StartPage.
        /// </summary>
        public int StartPage { get; set; } = 1;

        /// <summary>
        /// Gets or Sets the PageCount.
        /// </summary>
        public int PageCount { get; set; } = 1;

        /// <summary>
        /// Gets the calculate property considering <see cref="Price"/> times <see cref="Quantity"/>.
        /// </summary>
        public decimal TotalPrice => Price * Quantity;

        /// <summary>
        /// Gets the calculated property considering <see cref="StartPage"/> and <see cref="PageCount"/>.
        /// </summary>
        public int EndPage => StartPage + PageCount - 1;

        //
        // Summary:
        //     Returns a string that represents the current object.
        //
        // Returns:
        //     A string that represents the current object.
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <param name="provider">Format Provider whichrenders the object to <see cref="string"/>.</param>
        /// <returns>A string that represents the current object.</returns>
        public virtual string ToString(IFormatProvider provider) => string.Format(provider, "{0}", this);
    }
}
