namespace FlpExporter.WavToMp4
{
    public class Mp4Exporter : IMp4Exporter
    {
        private readonly Mp4ExporterOptions _options;

        public Mp4Exporter(Mp4ExporterOptions options)
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
