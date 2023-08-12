using FlpExporter.FlpExport;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;

namespace FlpExporter.Jobs
{
    public class FullExportOptions
    {
        public FullExportOptions(
            FlpExportOptions flpExportOptions, 
            YoutubeExportOptions youtubeExportOptions,
            Mp4ExportOptions mp4ExportOptions,
            bool FlpExportStage,
            bool ExportToYoutubeStage,
            bool RenderVidsStage
            )
        {
            FlpExportOptions = flpExportOptions;
            YoutubeExportOptions = youtubeExportOptions;
            Mp4ExportOptions = mp4ExportOptions;
            this.FlpExportStage = FlpExportStage;
            this.ExportToYoutubeStage = ExportToYoutubeStage;
            this.RenderVidsStage = RenderVidsStage;
        }

        public FlpExportOptions FlpExportOptions { get; }
        public YoutubeExportOptions YoutubeExportOptions { get; }
        public Mp4ExportOptions Mp4ExportOptions { get; }
        public bool FlpExportStage { get; }
        public bool ExportToYoutubeStage { get; }
        public bool RenderVidsStage { get; }
    }
}
