namespace FlpExporter.Abstract
{
    public abstract class BaseExporter
    {
        protected string[] GetFiles(string path, string format)
        {
            //var directory = Path.Combine(Directory.GetCurrentDirectory(), path);
            var files = Directory.GetFiles(path, $"*.{format}", SearchOption.TopDirectoryOnly);
            return files;
        }

        protected string Wrap(string str)
        {
            return @"""" + str + @"""";
        }
    }
}
