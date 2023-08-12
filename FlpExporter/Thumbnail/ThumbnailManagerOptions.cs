namespace FlpExporter.Thumbnail
{
    public class ThumbnailManagerOptions
    {
        public ThumbnailManagerOptions(string thumbnailsFolder)
        {
            ThumbnailsFolder = thumbnailsFolder;
        }

        public string ThumbnailsFolder { get; }
    }
}
