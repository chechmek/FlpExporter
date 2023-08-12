namespace FlpExporterConsoleUI.Jobs
{
    public class Folders
    {
        public Folders(string audioFolder, string videoFolder, string flpFolder, string thumbnailsFolder)
        {
            AudioFolder = audioFolder;
            VideoFolder = videoFolder;
            FlpFolder = flpFolder;
            ThumbnailsFolder = thumbnailsFolder;
        }

        public string AudioFolder { get; }
        public string VideoFolder { get; }
        public string FlpFolder { get; }
        public string ThumbnailsFolder { get; }
    }
}
