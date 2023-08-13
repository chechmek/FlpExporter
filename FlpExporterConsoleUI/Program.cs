using FlpExporter;
using FlpExporter.FlpExport;
using FlpExporter.Jobs;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.Thumbnail;
using FlpExporter.WavToMp4;
using FlpExporterConsoleUI.UI;
using System.Text.Json;

var console = new ConsoleUI();

//Folders folders = new Folders(
//    audioFolder: "audio",
//    videoFolder: "videos",
//    thumbnailsFolder: "thumbnails",
//    flpFolder: "flp");
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

string jsonFilePath = @".\settings\config.json";
string jsonData = File.ReadAllText(jsonFilePath);

try
{
    // Try to parse the JSON
    JsonDocument.Parse(jsonData);
    console.LogSuccess("Config is valid.");
}
catch (JsonException ex)
{
    console.LogError("Config is not valid. Error: \n" + ex.Message);
    return;
}

var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true // For pretty-printing the JSON output
};

FullExportOptions fullExportOptions = JsonSerializer.Deserialize<FullExportOptions>(jsonData, options);

FullExportJob job = new(fullExportOptions, console);

ConsoleSnippents.ShowStartScreen();
Console.WriteLine(fullExportOptions.ToString());

job.Run();

Console.ReadLine();

