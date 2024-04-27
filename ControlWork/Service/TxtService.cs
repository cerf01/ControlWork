using ControlWork.Abstarction;
using ControlWork.Model;
using System.Reflection;

namespace ControlWork.Service
{
	public class TxtService : IFileService
	{
		private List<string> GetEachLine(string originalString)
		{
			char[] illegalSymbols = { '\t', '\n' };

			var words = originalString.Split(illegalSymbols);

			return words.Where(word => word.Length > 0).ToList();
		}
		public T GetFromFile<T>(string path) where T : class
		{

			var stringFromFile = File.ReadAllText(path);

			var strings = GetEachLine(stringFromFile);

			var valuers = new List<string>();

			var books = new List<Book>();

			foreach (var line in strings)
			{
				valuers.Add(line);
				if (valuers.Count == 5)
				{
					books.Add(new Book(valuers));
					foreach (var item in valuers)
						Console.WriteLine(item);
					valuers.Clear();
				}
			}
			return (T)(object)books;
		}

		public void SaveToFile<T>(T file, string path) where T : class
		{
			string buffer = "";

			if (Path.Exists(path))
				buffer = File.ReadAllText(path);

			File.WriteAllText(path, buffer + "\n" + file.ToString()+"\n");
		}
	}
}
