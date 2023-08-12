using FlpExporter;
using FlpExporter.FlpExport;
using FlpExporter.Jobs;
using FlpExporter.Mp4ToYoutube;
using FlpExporter.WavToMp4;
using FlpExporterConsoleUI.UI;

var console = new ConsoleUI();

FlpExportOptions flpExportOptions = new()
{
    fl64Location = @"C:\Program Files\Image-Line\FL Studio 20\FL64.exe",
    outputFolder = Locations.AudioFolder,
    RenderMp3 = true
};
YoutubeExportOptions youtubeExportOptions = new();
Mp4ExportOptions mp4ExportOptions = new();

FullExportOptions fullExportOptions = new FullExportOptions(
    flpExportOptions, 
    youtubeExportOptions, 
    mp4ExportOptions,
    FlpExportStage: false,
    RenderVidsStage: true,
    ExportToYoutubeStage: false);

FullExportJob job = new(fullExportOptions, console);

ConsoleSnippents.ShowStartScreen();

job.Run();

Console.ReadLine();