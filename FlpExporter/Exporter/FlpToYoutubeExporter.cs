using FlpExporter.Exporter.Models;
using FlpExporter.Stages;

namespace FlpExporter.Exporter
{
    public class FlpToYoutubeExporter : IExporter
    {
        private readonly FlpToYoutubeExporterOptions _options;

        public FlpToYoutubeExporter(FlpToYoutubeExporterOptions options)
        {
            _options = options;
        }

        public async Task Export()
        {
            IStage flpRenderStage = new FlpRenderStage(_options.FlpRenderOptions);
            // Render flp to wav,mp3

            // Create mp4

            // Send to youtube

            throw new NotImplementedException();
        }
    }
}
