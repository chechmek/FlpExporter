using FlpExporter.Abstract;
using FlpExporter.Logging;
using System.Diagnostics;

namespace FlpExporter.FlpExport
{
    public class FlpAudioExporter : BaseExporter, IFlpExporter
    {
        private readonly FlpExportOptions _options;
        private readonly ILogger _logger;
        private string formats;
        private string fl64Location;
        private string destinationFolder;

        public FlpAudioExporter(FlpExportOptions options, ILogger logger)
        {
            _options = options;
            _logger = logger;
            formats = GetFormatsString(options.RenderMp3);
            fl64Location = options.fl64Location;
            destinationFolder = Path.Combine(Directory.GetCurrentDirectory(), options.outputFolder);
        }

        public void Export(string path)
        {
            if (!File.Exists(path))
                _logger.Log($"File {path} does not exist!");

            throw new NotImplementedException();
        }

        public void ExportAll(string folder)
        {
            if (!Directory.Exists(folder))
            {
                _logger.LogError($"Directory {folder} does not exist!");
                _logger.LogError("Skipping flp export!");
                return;
            }

            string[] flpFiles = GetFiles(folder, "flp");
            int fileCount = flpFiles.Length;
            _logger.LogInfo($"Found {fileCount} .flp files in {folder}");
            if(fileCount == 0)
            {
                _logger.LogError("Skipping flp export!");
                return;
            }

            foreach (string file in flpFiles)
                _logger.LogInfo(file);

            if (!Directory.Exists(destinationFolder))
                _logger.LogError($"Output directory {destinationFolder} not found, audio will be saved to flp location");
            else
                _logger.LogInfo($"Audio will be saved to {destinationFolder}");

            foreach(string file in flpFiles)
            {
                ExportFlp(file);
            }

            ShowResults();
            _logger.LogSuccess("Flp export all job finished!");
        }

        private void ShowResults()
        {
            if (_options.RenderMp3)
            {
                string[] mp3Files = GetFiles(destinationFolder, "mp3");
                _logger.LogInfo($"Rendered {mp3Files.Length} .mp3 files");
            }
            
            string[] wavFiles = GetFiles(destinationFolder, "wav");
            _logger.LogInfo($"Rendered {wavFiles.Length} .wav files");
        }

        private void ExportFlp(string flpLocation)
        {
            string exportAudioCommand = @$"{Wrap(fl64Location)} /E{formats} /R /O{Wrap(destinationFolder)} {Wrap(@".\" + flpLocation)}";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(exportAudioCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            _logger.Log(cmd.StandardOutput.ReadToEnd());
        }

        private string GetFormatsString(bool renderMp3)
        {
            if (renderMp3)
                return "mp3,wav";
            else
                return "wav";
        }

        
    }
}
