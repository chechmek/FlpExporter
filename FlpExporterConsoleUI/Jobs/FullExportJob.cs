using FlpExporter.FlpExport;
using FlpExporter.Logging;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.Thumbnail;
using FlpExporter.WavToMp4;
using FlpExporterConsoleUI.UI;

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
            IThumbnailManager thumbnailManager = new ThumbnailManager(logger);
            _mp4Exporter = new Mp4Exporter(options.Mp4ExportOptions, logger, thumbnailManager);
        }

        public void Run()
        {
            if (_options.FlpExportStage)
            {
                ConsoleSnippents.ShowFlRender();
                _flpExporter.ExportAll(Locations.FlpFolder);
            }

            if (_options.RenderVidsStage)
            {
                ConsoleSnippents.ShowMp4Render();
                _mp4Exporter.ExportAll(Locations.AudioFolder);
            }

            if (_options.ExportToYoutubeStage)
            {
                ConsoleSnippents.ShowYoutubeExport();
                _youtubeExporter.ExportAll(Locations.VideoFolder);
            }
            
        }
    }
}
