using System.Text.Json.Serialization;

namespace FlpExporter.FlpExport
{
    public class FlpExportOptions
    {
        public FlpExportOptions(bool renderMp3, string outputFolder, string fl64Location, string flpFolder)
        {
            RenderMp3 = renderMp3;
            this.outputFolder = outputFolder;
            this.fl64Location = fl64Location;
            FlpFolder = flpFolder;
        }

        [JsonRequired]
        public bool RenderMp3 { get; set; }
        [JsonRequired]
        public string outputFolder { get; set; }
        [JsonRequired]
        public string fl64Location { get; set; }
        [JsonRequired]
        public string FlpFolder { get; set; }
    }
}
