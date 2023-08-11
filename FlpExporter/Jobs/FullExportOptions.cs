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
            Mp4ExportOptions mp4ExportOptions
            )
        {
            FlpExportOptions = flpExportOptions;
            YoutubeExportOptions = youtubeExportOptions;
            Mp4ExportOptions = mp4ExportOptions;
        }

        public FlpExportOptions FlpExportOptions { get; set; }
        public YoutubeExportOptions YoutubeExportOptions { get; }
        public Mp4ExportOptions Mp4ExportOptions { get; }
    }
}
