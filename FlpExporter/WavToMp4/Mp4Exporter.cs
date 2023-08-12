using FFMpegCore;
using FlpExporter.Abstract;
using FlpExporter.Logging;
using FlpExporter.Thumbnail;
using System.Diagnostics;

namespace FlpExporter.WavToMp4
{
    public class Mp4Exporter : BaseExporter, IMp4Exporter
    {
        private readonly Mp4ExportOptions _options;
        private readonly ILogger _logger;
        private readonly string ffmpegLocation = @".\ffmpeg\bin\ffmpeg.exe";
        private readonly string vidFolder = @".\videos";
        private readonly string audioFolder = @".\audio";
        private readonly IThumbnailManager _thumbnailManager;

        public Mp4Exporter(Mp4ExportOptions options, ILogger logger, IThumbnailManager thumbnailManager)
        {
            _options = options;
            _logger = logger;
            _thumbnailManager = thumbnailManager;   
        }

        public void Export(string path)
        {
            throw new NotImplementedException();
        }

        public void ExportAll(string folder)
        {
            ClearDirectory();

            string[] wavFiles = GetFiles(audioFolder, "wav");
            _logger.LogInfo($"Wav files to use in vids ({wavFiles.Length})");
            foreach (string wavFile in wavFiles)
                _logger.LogInfo(wavFile);

            string imgFile = @".\thumbnails\img.jpg";

            RenderAllMp4(wavFiles);

            string[] mp4Files = GetFiles(vidFolder, "mp4");
            _logger.LogSuccess($"Successfully rendered {mp4Files.Length} mp4 files!");
        }

        private void ClearDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(vidFolder);

            string[] mp4Files = GetFiles(vidFolder, "mp4");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private void RenderAllMp4(string[] wavFiles)
        {
            

            foreach (var wavFile in wavFiles)
            {
                string imgFile = _thumbnailManager.GetThumbnailPath();

                string vidFile = $@"{vidFolder}\{Path.GetFileNameWithoutExtension(wavFile)}.mp4";
                string ffmpegCommand = $@"{Wrap(ffmpegLocation)} -loop 1 -i {Wrap(imgFile)} -i {Wrap(wavFile)} -c:v libx264 -tune stillimage -c:a aac -b:a 192k -pix_fmt yuv420p -shortest -vf ""scale=1280:720"" {Wrap(vidFile)}";
                string ffmpegArgs = $@"-loop 1 -i {Wrap(imgFile)} -i {Wrap(wavFile)} -c:v libx264 -tune stillimage -c:a aac -b:a 192k -pix_fmt yuv420p -shortest -vf ""scale=1280:720"" {Wrap(vidFile)}";

                _logger.LogSuccess($"Rendering {vidFile}");

                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = ffmpegLocation;
                startInfo.Arguments = ffmpegArgs;
                startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;

                Console.WriteLine(string.Format(
                    "Executing \"{0}\" with arguments \"{1}\".\r\n",
                    startInfo.FileName,
                    startInfo.Arguments));

                try
                {
                    using (Process process = Process.Start(startInfo))
                    {
                        while (!process.StandardOutput.EndOfStream)
                        {
                            string line = process.StandardOutput.ReadLine();
                            Console.WriteLine(line);
                        }

                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                _logger.LogSuccess($"Rendered {vidFile}");
            }

        }

        private void RenderMp4(string imgPath, string audioPath, string vidPath)
        {

        }
    }
}
