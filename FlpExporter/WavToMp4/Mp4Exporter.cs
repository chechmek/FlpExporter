using FlpExporter.Logging;

namespace FlpExporter.WavToMp4
{
    public class Mp4Exporter : IMp4Exporter
    {
        private readonly Mp4ExportOptions _options;
        private readonly ILogger _logger;

        public Mp4Exporter(Mp4ExportOptions options, ILogger logger)
        {
            _options = options;
            _logger = logger;
        }

        public void Export(string path)
        {
            //FFMpeg.PosterWithAudio(inputPath, inputAudioPath, outputPath);
            //// or
            //var image = Image.FromFile(inputImagePath);
            //image.AddAudio(inputAudioPath, outputPath);
            throw new NotImplementedException();
        }

        public void ExportAll(string folder)
        {
            throw new NotImplementedException();
        }
    }
}
