namespace ControlWork.Model
{
	public class Book
	{
		public string Title { get;  set; }
		public string Genre { get;  set; }
		public string Author { get;  set; }
		public string Publisher { get;  set; }
		public DateTime PublicationDate { get;  set; }

		public Book()
		{
			Title = "I have no mouth and i must scream";
			Genre = "Post-apocalyptic fiction";
			Author = "Harlan Ellison";	
			Publisher = "Galaxy Publishing Corp";
			PublicationDate = new DateTime(1967, 3, 1);
		}
		public Book(List<string> bookInfo)
		{
			Title = bookInfo[0];
			Genre = bookInfo[1];
			Author = bookInfo[2];
			Publisher = bookInfo[3];
			PublicationDate = DateTime.Parse(bookInfo[4]);
		}

		public Book(string title, string gener, string author, string publisher,string publicationDate)
		{
			Title = title;
			Genre = gener;
			Author = author;
			Publisher = publisher;
			PublicationDate = DateTime.Parse(publicationDate);
		}

		public override string ToString() =>
		   $"{Title}\n{Genre}\n{Author}\n{Publisher}\n{PublicationDate}";
	}
}
