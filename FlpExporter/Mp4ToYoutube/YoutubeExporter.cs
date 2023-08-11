namespace FlpExporter.Mp4ToYoutube
{
    public class YoutubeExporter : IYoutubeExporter
    {
        private readonly YoutubeExportOptions _options;

        public YoutubeExporter(YoutubeExportOptions options)
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
