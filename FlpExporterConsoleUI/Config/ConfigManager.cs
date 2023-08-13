using FlpExporter.Jobs;
using FlpExporter.Logging;
using System.Text.Json;

namespace FlpExporterConsoleUI.Config
{
    public class ConfigManager
    {
        private readonly ILogger _logger;

        public ConfigManager(ILogger logger)
        {
            _logger = logger;
        }

        public FullExportOptions GetFullExportJobSettings()
        {
            string jsonFilePath = @".\settings\config.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            try
            {
                // Try to parse the JSON
                JsonDocument.Parse(jsonData);
                _logger.LogSuccess("Config is valid.");
            }
            catch (JsonException ex)
            {
                _logger.LogError("Config is not valid. Error: \n" + ex.Message);
                throw;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true // For pretty-printing the JSON output
            };

            FullExportOptions fullExportOptions = JsonSerializer.Deserialize<FullExportOptions>(jsonData, options)!;

            return fullExportOptions;
        }
    }
}

//FlpExportOptions flpExportOptions = new(
//    fl64Location: @"C:\Program Files\Image-Line\FL Studio 20\FL64.exe",
//    outputFolder: folders.AudioFolder,
//    renderMp3: true
//    );
//ThumbnailManagerOptions thumbnailManagerOptions = new(
//    thumbnailsFolder: folders.ThumbnailsFolder);
//Mp4ExportOptions mp4ExportOptions = new(
//    audioFolder: folders.AudioFolder,
//    vidFolder: folders.VideoFolder,
//    ffmpegLocation: @".\ffmpeg\bin\ffmpeg.exe",
//    thumbnailManagerOptions: thumbnailManagerOptions
//    );

//YoutubeExportOptions youtubeExportOptions = new();

//FullExportOptions fullExportOptions = new FullExportOptions(
//    flpExportOptions, 
//    youtubeExportOptions, 
//    mp4ExportOptions,
//    folders: folders,
//    flpExportStage: false,
//    renderVidsStage: true,
//    exportToYoutubeStage: false
//    );