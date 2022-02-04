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
    }
}
