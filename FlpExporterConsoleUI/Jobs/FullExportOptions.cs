using FlpExporter.FlpExport;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;
using FlpExporterConsoleUI.Jobs;
using System.Text.Json;

namespace FlpExporter.Jobs
{
    public class FullExportOptions
    {
        public FullExportOptions(FlpExportOptions flpExportOptions, YoutubeExportOptions youtubeExportOptions, Mp4ExportOptions mp4ExportOptions, bool flpExportStage, bool exportToYoutubeStage, bool renderVidsStage, Folders folders)
        {
            FlpExportOptions = flpExportOptions;
            YoutubeExportOptions = youtubeExportOptions;
            Mp4ExportOptions = mp4ExportOptions;
            FlpExportStage = flpExportStage;
            ExportToYoutubeStage = exportToYoutubeStage;
            RenderVidsStage = renderVidsStage;
            Folders = folders;
        }

        public FlpExportOptions FlpExportOptions { get; }
        public YoutubeExportOptions YoutubeExportOptions { get; }
        public Mp4ExportOptions Mp4ExportOptions { get; }
        public bool FlpExportStage { get; }
        public bool ExportToYoutubeStage { get; }
        public bool RenderVidsStage { get; }
        public Folders Folders { get; }

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
