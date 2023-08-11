namespace FlpExporter.Abstract
{
    public interface IExporter
    {
        void ExportAll(string folder);
        void Export(string path);
    }
}
