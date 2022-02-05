using System.Linq;

namespace Cascade.Challenges.Books.Mvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Data;

    /// <summary>
    /// 
    /// </summary>
    public class BooksController : Controller
    {
        /// <summary>
        /// Template Instance for internal use.
        /// </summary>
        private Book TemplateInstance { get; } = new Book();

        /// <summary>
        /// Gets the Context for the Controller.
        /// </summary>
        private BooksDbContext Context { get; }

        /// <summary>
        /// Default dependency injected ctor.
        /// </summary>
        public BooksController(BooksDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Yields the default View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => IndexBy();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult IndexByPub() => IndexBy("pub");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult IndexByAuth() => IndexBy("auth");

        /// <summary>
        /// Defers <see cref="Index"/> By the <paramref name="key"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActionResult IndexBy(string key = "")
        {
            ViewBag.Template = TemplateInstance;
            return View("Views/Books/Index.cshtml", Context.GetBooksBy(key));
        }

        /// <summary>
        /// Yields the TotalPrice of all off the Books, their <see cref="Book.Price"/> over
        /// <see cref="Book.Quantity"/>, or as quantified by <see cref="Book.TotalPrice"/>.
        /// </summary>
        /// <returns></returns>
        public IActionResult TotalPrice()
        {
            // Creates separateion from EF and the database to access the computed property:
            var totalPriceSum = Context.Books.AsEnumerable().Sum(x => x.TotalPrice);
            //                               ^^^^^^^^^^^^^^^

            // TODO: TBD: this is returning as the total-total price, so to speak...
            // TODO: TBD: losing accountability with each book, quantity in stock, etc
            // TODO: TBD: would be one area that could be improved, even formalized into a formal DTO model

            return Json(new { TotalPrice = totalPriceSum });
        }
    }
}
