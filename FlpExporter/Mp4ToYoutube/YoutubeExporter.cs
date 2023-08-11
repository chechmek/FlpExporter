using FlpExporter.Logging;

namespace FlpExporter.Mp4ToYoutube
{
    public class YoutubeExporter : IYoutubeExporter
    {
        private readonly YoutubeExportOptions _options;
        private readonly ILogger _logger;

        public YoutubeExporter(YoutubeExportOptions options, ILogger logger)
        {
            _options = options;
            _logger = logger;
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
