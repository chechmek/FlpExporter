using FlpExporter.Thumbnail;
using System.Text.Json.Serialization;

namespace FlpExporter.WavToMp4
{
    public class Mp4ExportOptions
    {
        public Mp4ExportOptions(ThumbnailManagerOptions thumbnailManagerOptions, string ffmpegLocation, string vidFolder, string audioFolder)
        {
            this.thumbnailManagerOptions = thumbnailManagerOptions;
            FfmpegLocation = ffmpegLocation;
            VidFolder = vidFolder;
            AudioFolder = audioFolder;
        }

        [JsonRequired]
        public ThumbnailManagerOptions thumbnailManagerOptions { get; set; }
        [JsonRequired]
        public string FfmpegLocation { get; set; }
        [JsonRequired]
        public string VidFolder { get; set; }
        [JsonRequired]
        public string AudioFolder { get; set; }
    }
}
