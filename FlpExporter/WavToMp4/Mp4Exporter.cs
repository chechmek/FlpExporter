using FFMpegCore;
using FlpExporter.Abstract;
using FlpExporter.Logging;
using System.Diagnostics;

namespace FlpExporter.WavToMp4
{
    public class Mp4Exporter : BaseExporter, IMp4Exporter
    {
        private readonly Mp4ExportOptions _options;
        private readonly ILogger _logger;
        private readonly string ffmpegLocation = @".\ffmpeg\bin\ffmpeg.exe";

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
            string audioPath = @".\audio";
            string[] wavFiles = GetFiles(audioPath, "wav");
            _logger.LogInfo($"Wav files to use in vids ({wavFiles.Length})");
            foreach (string wavFile in wavFiles)
                _logger.LogInfo(wavFile);

            string imgPath = @".\thumbnails\img.jpg";
            string inputAudioPath = @".\audio\ggsong.wav";
            string vidFolder = @".\videos";

            foreach (var wavFile in wavFiles)
            {
                string vidFile = $@"{vidFolder}\{Path.GetFileNameWithoutExtension(wavFile)}.mp4";
                RenderMp4(imgPath, wavFile, vidFile);
            }

            
        }

        private void RenderMp4(string imgPath, string audioPath, string vidPath)
        {
            string ffmpegCommand = $@"{Wrap(ffmpegLocation)} -loop 1 -i {Wrap(imgPath)} -i {Wrap(audioPath)} -c:v libx264 -tune stillimage -c:a aac -b:a 192k -pix_fmt yuv420p -shortest -vf ""scale=1280:720"" {Wrap(vidPath)}";

            Process ffmpegProccess = new Process();
            ffmpegProccess.StartInfo.FileName = "cmd.exe";
            ffmpegProccess.StartInfo.RedirectStandardInput = true;
            ffmpegProccess.StartInfo.RedirectStandardOutput = true;
            ffmpegProccess.StartInfo.CreateNoWindow = true;
            ffmpegProccess.StartInfo.UseShellExecute = false;
            ffmpegProccess.Start();

            ffmpegProccess.StandardInput.WriteLine(ffmpegCommand);
            ffmpegProccess.StandardInput.Flush();
            ffmpegProccess.StandardInput.Close();
            ffmpegProccess.WaitForExit();
            _logger.Log(ffmpegProccess.StandardOutput.ReadToEnd());
        }
    }
}
