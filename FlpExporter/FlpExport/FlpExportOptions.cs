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

        public bool RenderMp3 { get; set; }
        public string outputFolder { get; set; }
        public string fl64Location { get; set; }
        public string FlpFolder { get; }
    }
}
