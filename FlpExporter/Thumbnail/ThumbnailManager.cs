using FlpExporter.Abstract;
using FlpExporter.Logging;

namespace FlpExporter.Thumbnail
{
    public class ThumbnailManager : BaseExporter, IThumbnailManager
    {
        private readonly ILogger _logger;
        private string _thumbnailsFolder = Locations.ThumbnailsFolder;

        public ThumbnailManager(ILogger logger)
        {
            _logger = logger;
        }
        public string GetThumbnailPath()
        {
            if (!Directory.Exists(_thumbnailsFolder))
            {
                _logger.LogError($"Directory {_thumbnailsFolder} does not exist!");
                throw new Exception("Cannot generate videos without thumbnails!");
            }

            //string[] imagesFiles = GetFiles(_thumbnailsFolder, "flp");
            //int fileCount = imagesFiles.Length;
            //_logger.LogInfo($"Found {fileCount} .flp files in {folder}");
            //if (fileCount == 0)
            //{
            //    _logger.LogError("Skipping flp export!");
            //    return;
            //}

            throw new NotImplementedException();
        }
    }
}
