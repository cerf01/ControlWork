namespace ControlWork.Abstarction
{
	public interface IFileService
	{
		public void SaveToFile<T>(T file, string path) where T : class;

		public T GetFromFile<T>(string path) where T : class;
	}
}
