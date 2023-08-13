using FlpExporter.FlpExport;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;
using System.Text.Json;

namespace FlpExporter.Jobs
{
    public class FullExportOptions
    {
        public FullExportOptions(FlpExportOptions flpExportOptions, YoutubeExportOptions youtubeExportOptions, Mp4ExportOptions mp4ExportOptions, bool flpExportStage, bool exportToYoutubeStage, bool renderVidsStage)
        {
            FlpExportOptions = flpExportOptions;
            YoutubeExportOptions = youtubeExportOptions;
            Mp4ExportOptions = mp4ExportOptions;
            FlpExportStage = flpExportStage;
            ExportToYoutubeStage = exportToYoutubeStage;
            RenderVidsStage = renderVidsStage;
        }

        public FlpExportOptions FlpExportOptions { get; }
        public YoutubeExportOptions YoutubeExportOptions { get; }
        public Mp4ExportOptions Mp4ExportOptions { get; }
        public bool FlpExportStage { get; }
        public bool ExportToYoutubeStage { get; }
        public bool RenderVidsStage { get; }

        public override string? ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true // For pretty-printing the JSON output
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
