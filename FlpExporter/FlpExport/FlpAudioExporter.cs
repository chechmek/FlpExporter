using FlpExporter.Logging;
using System.Diagnostics;

namespace FlpExporter.FlpExport
{
    public class FlpAudioExporter : IFlpExporter
    {
        private readonly ILogger _logger;
        private string formats;
        private string fl64Location;
        private string destinationFolder;

        public FlpAudioExporter(FlpExportOptions options, ILogger logger)
        {
            _logger = logger;
            formats = GetFormatsString(options.RenderMp3);
            fl64Location = options.fl64Location;
            destinationFolder = options.outputFolder;
        }

        public void Export(string path)
        {
            if (!File.Exists(path))
                _logger.Log($"File {path} does not exist!");

            ExportFlp(path);
        }

        public void ExportAll(string folder)
        {
            if (!Directory.Exists(folder))
            {
                _logger.LogError($"Directory {folder} does not exist!");
                _logger.LogError("Skipping flp export!");
                return;
            }

            string[] files = GetFlpFiles(folder);
            int fileCount = files.Length;
            _logger.LogInfo($"Found {fileCount} .flp files in {folder}");
            if(fileCount == 0)
            {
                _logger.LogError("Skipping flp export!");
                return;
            }

            foreach (string file in files)
                _logger.LogInfo(file);

            ExportFlp(folder);

            _logger.LogSuccess("Flp export all job finished!");
        }

        private void ExportFlp(string flpLocation)
        {
            string exportAudioCommand = @$"{Wrap(fl64Location)} /E{formats} /R /O{Wrap(destinationFolder)} {Wrap(flpLocation)}";

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

        private string[] GetFlpFiles(string path)
        {
            //var directory = Path.Combine(Directory.GetCurrentDirectory(), path);
            var files = Directory.GetFiles(path, "*.flp", SearchOption.TopDirectoryOnly);
            return files;
        }

        private string Wrap(string str)
        {
            return @"""" + str + @"""";
        }
    }
}
