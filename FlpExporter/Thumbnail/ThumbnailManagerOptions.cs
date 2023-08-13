using System.Text.Json.Serialization;

namespace FlpExporter.Thumbnail
{
    public class ThumbnailManagerOptions
    {
        public ThumbnailManagerOptions(string thumbnailsFolder)
        {
            ThumbnailsFolder = thumbnailsFolder;
        }

        [JsonRequired]
        public string ThumbnailsFolder { get; set; }
    }
}
