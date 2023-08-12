using FlpExporter.Abstract;
using FlpExporter.Logging;

namespace FlpExporter.Thumbnail
{
    public class ThumbnailManager : BaseExporter, IThumbnailManager
    {
        private readonly ILogger _logger;
        private string _thumbnailsFolder;
        private HashSet<string> _thumbnails = new HashSet<string>();

        public ThumbnailManager(ILogger logger, ThumbnailManagerOptions thumbnailManagerOptions)
        {
            _logger = logger;
            _thumbnailsFolder = thumbnailManagerOptions.ThumbnailsFolder;
        }
        public string GetThumbnailPath()
        {
            if (!Directory.Exists(_thumbnailsFolder))
            {
                _logger.LogError($"Directory {_thumbnailsFolder} does not exist!");
                throw new Exception("Cannot generate videos without thumbnails!");
            }

            string[] jpgFiles = GetFiles(_thumbnailsFolder, "jpg");
            string[] pngFiles = GetFiles(_thumbnailsFolder, "png");
            string[] imagesFiles = new string[jpgFiles.Length + pngFiles.Length];
            jpgFiles.CopyTo(imagesFiles, 0);
            pngFiles.CopyTo(imagesFiles, jpgFiles.Length);


            int fileCount = imagesFiles.Length;
            _logger.LogInfo($"Found {fileCount} .flp files in {_thumbnailsFolder}");
            if (fileCount == 0)
            {
                _logger.LogError($"No thumbnails found!");
                throw new Exception("Cannot generate videos without thumbnails!");
            }

            foreach (var image in imagesFiles)
            {
                if (_thumbnails.Contains(image))
                    continue;

                _thumbnails.Add(image);
                return image;
            }

            throw new Exception("You used all images");
        }
    }
}
