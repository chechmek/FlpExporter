namespace FlpExporter.FlpRender
{
    public class FlpExporter : IFlpExporter
    {
        private readonly FlpRenderOptions _options;

        public FlpExporter(FlpRenderOptions options)
        {
            _options = options;
        }

        public void Export(string path)
        {
            throw new NotImplementedException();
        }

        public void ExportAll(string folder)
        {
            throw new NotImplementedException();
        }
    }
}
