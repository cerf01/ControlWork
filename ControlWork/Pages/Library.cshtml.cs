using ControlWork.Abstarction;
using ControlWork.Model;
using ControlWork.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ControlWork.Pages
{
    public class LibraryModel : PageModel
    {
        private readonly IFileService _fileService;
        public List<string> BooksTitles { get;private set; }

        private string _path;

		public LibraryModel(IFileService fileService)
        {
            _fileService = fileService;

            BooksTitles = new List<string>();

			_path = "Books.txt";
		}

		private void SaveData() 
		{
			if (Path.GetExtension(_path) == ".txt")
				foreach (var book in BooksContainer.Books)
					_fileService.SaveToFile(book, _path);

			else if (Path.GetExtension(_path) == ".json")
				_fileService.SaveToFile(BooksContainer.Books, _path);
		}

        private void CheckContains() 
        {
			if (BooksContainer.Books.Capacity <= 0)
			{
				BooksContainer.Books.Add(new Book());

				BooksContainer.Books.Add(new Book("Animal Farm", "Political satire", "George Orwell", "Secker and Warburg", "1945-08-17T00:00:00"));

				BooksContainer.Books.Add(new Book("The Metamorphosis", "Novella", "Franz Kafka", "Kurt Wolff Verlag, Leipzig", "1915-10-01T00:00:00"));
				
				SaveData();
			}
			else
				return;
		}

        public void OnGet()
        {
			if (BooksContainer.Books.Capacity <= 0)
            {
				BooksContainer.SetBookList(Path.Exists(_path) ? _fileService.GetFromFile<List<Book>>(_path) : new List<Book>() { });
				
				CheckContains();
			}
			BooksContainer.Books.ForEach(b => BooksTitles.Add(b.Title));
		}
    }
}
