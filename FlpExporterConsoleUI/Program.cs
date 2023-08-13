using FlpExporter.Jobs;
using FlpExporterConsoleUI.Config;
using FlpExporterConsoleUI.UI;

var console = new ConsoleUI();
var configManager = new ConfigManager(console);
var fullExportOptions = configManager.GetFullExportJobSettings();
FullExportJob job = new(fullExportOptions, console);

ConsoleSnippents.ShowStartScreen();
console.Log(fullExportOptions.ToString()!);

job.Run();

console.LogSuccess("Експорт завершений, гарного дня!");
Console.ReadLine();