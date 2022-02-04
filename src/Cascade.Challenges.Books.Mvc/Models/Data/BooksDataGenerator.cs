using System;

namespace Cascade.Challenges.Books.Mvc.Models.Data
{
    using LoremNET;
    using static String;

    /// <summary>
    /// A random <see cref="Book"/> generator.
    /// </summary>
    public class BooksDataGenerator
    {
        /// <summary>
        /// Default ctor.
        /// </summary>
        public BooksDataGenerator()
        {
        }

        /// <summary>
        /// Space used for delimiter building the <see cref="LoremString(int)"/>.
        /// </summary>
        private const string Space = " ";

        /// <summary>
        /// Returns a randomly generated <see cref="string"/> of <paramref name="wordCount"/>.
        /// </summary>
        /// <param name="wordCount"></param>
        /// <returns></returns>
        private string LoremString(int wordCount = 3) => Join(Space, Lorem.Words(wordCount));

        /// <summary>
        /// Returns a randomly generated <see cref="long"/> value between <paramref name="min"/>
        /// and <paramref name="max"/> values.
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        /// <remarks>From a usage perspective, we reverse <paramref name="min"/> and
        /// <paramref name="max"/> for caller convenience</remarks>
        private long LoremLong(long max = short.MaxValue, long min = 0) => Lorem.Number(min, max);

        /// <summary>
        /// Returns a randomly generated date time.
        /// </summary>
        /// <returns></returns>
        private DateTimeOffset LoremDateTime() => Lorem.DateTime();

        /// <summary>
        /// Generates a random Book Title completely using Lorem generated data.
        /// </summary>
        /// <returns></returns>
        internal Book Generate() => new Book
        {
            Publisher = LoremString(),
            PublishedOn = LoremDateTime(),
            Title = LoremString((int)(LoremLong(7) + 1)),
            AuthorLastName = LoremString(1),
            AuthorFirstName = LoremString(1),
            PageCount = (int)LoremLong(),
            Price = ((decimal)LoremLong()) / 100,
            Quantity = (int)LoremLong(),
        };
    }
}
