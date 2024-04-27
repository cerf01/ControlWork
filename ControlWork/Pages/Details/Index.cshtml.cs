using ControlWork.Model;
using ControlWork.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControlWork.Pages.Details
{
    public class IndexModel : PageModel
    {
        public Book Book { get;private set; }
        public int BookIndex { get;private set; }
        public void OnGet(int bookIndex)
        {
			BookIndex = bookIndex;

            Book = BooksContainer.Books[BookIndex];
        }

        public int MovedNext()
        {
            if (BookIndex+1 >= BooksContainer.Books.Count)
                return BookIndex;

			return BookIndex + 1;
        }
		public int MovedPrev()
		{
			if (BookIndex - 1 < 0)
				return BookIndex;

			return BookIndex - 1;
		}
	}
}
