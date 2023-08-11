using FlpExporter.FlpExport;
using FlpExporter.Logging;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;

namespace FlpExporter.Jobs
{
    public class FullExportJob : IJob
    {
        private readonly FullExportOptions _options;
        private readonly ILogger _logger;
        private readonly IFlpExporter _flpExporter;
        private readonly IYoutubeExporter _youtubeExporter;
        private readonly IMp4Exporter _mp4Exporter;

        public FullExportJob(FullExportOptions options, ILogger logger)
        {
            _options = options;
            _logger = logger;
            _flpExporter = new FlpAudioExporter(options.FlpExportOptions, logger);
            _youtubeExporter = new YoutubeExporter(options.YoutubeExportOptions, logger);
            _mp4Exporter = new Mp4Exporter(options.Mp4ExportOptions, logger);
        }

        public void Run()
        {
            _flpExporter.ExportAll(Locations.FlpFolder);
            _mp4Exporter.ExportAll(Locations.AudioFolder);
            _youtubeExporter.ExportAll(Locations.VideoFolder);
        }
    }
}
