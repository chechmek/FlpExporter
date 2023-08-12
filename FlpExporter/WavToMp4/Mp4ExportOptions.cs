using FlpExporter.Thumbnail;

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

        public ThumbnailManagerOptions thumbnailManagerOptions { get; }
        public string FfmpegLocation { get; set; }
        public string VidFolder { get; set; }
        public string AudioFolder { get; set; }
    }
}
