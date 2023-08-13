using FlpExporter.FlpExport;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [JsonRequired]
        public FlpExportOptions FlpExportOptions { get; set; }
        [JsonRequired]
        public YoutubeExportOptions YoutubeExportOptions { get; set; }
        [JsonRequired]
        public Mp4ExportOptions Mp4ExportOptions { get; set; }
        [JsonRequired]
        public bool FlpExportStage { get; set; }
        [JsonRequired]
        public bool ExportToYoutubeStage { get; set; }
        [JsonRequired]
        public bool RenderVidsStage { get; set; }

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
