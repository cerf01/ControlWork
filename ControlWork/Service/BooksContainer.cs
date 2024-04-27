using ControlWork.Model;

namespace ControlWork.Service
{
	public static class BooksContainer
	{
		public static List<Book> Books { get;private set; }
		 static BooksContainer() => 
			Books = new List<Book>();

		public static void SetBookList(List<Book> books) =>
			Books = books;

	}
}
