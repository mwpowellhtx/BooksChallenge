using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Cascade.Challenges.Books.Mvc.Models.Data
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public class BooksDbContext : DbContext
    {
        /// <summary>
        /// Options based constructor for dependency injection usage.
        /// </summary>
        /// <param name="options">Relay the Options to the base class.</param>
        public BooksDbContext(DbContextOptions<BooksDbContext> options, BooksDataGenerator generator) : base(options)
        {

#if DEBUG
            if (!Books.Any())
            {
                GenerateBooks(generator);
            }
#endif // DEBUG

        }

        /// <summary>
        /// Feeds the database with some randomly generated Lorem inspired data.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="bookCount"></param>
        private void GenerateBooks(BooksDataGenerator generator, int bookCount = 10)
        {
            // Used strictly as placeholders which to replace with actual Book instances
            var booksToAdd = Enumerable.Range(0, bookCount).Select(_ => generator.Generate());
            //               ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            // And add the range of randomly generated Books to add to the database
            Books.AddRange(booksToAdd);

            SaveChanges();
        }

        ///// <inheritdoc/>
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Book>().HasKey(x => x.Id);
        //}

        /// <summary>
        /// Gets the default set of Books from the database.
        /// </summary>
        /// <remarks>Which is automatically injected for us.</remarks>
        protected virtual DbSet<Book> Books { get; set; }

        /// <summary>
        /// Returns the <see cref="IEnumerable{T}"/> set of <see cref="Book"/> entities aligned
        /// with the <paramref name="key"/> from the database.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual IEnumerable<Book> GetBooksBy(string key = "")
        {
            // Relay the KEY parameter when it is one among the expected
            if (new[] { "pub", "auth", "publisher", "author" }.Contains(key.ToLowerInvariant()))
            {
                var keyParam = new SqlParameter(nameof(key), SqlDbType.VarChar, 9) { Value = key };
                return Books.FromSqlRaw("exec GetBooksBy", keyParam).ToList();
            }

            return Books.FromSqlRaw("exec GetBooksBy").ToList();
        }
    }
}
