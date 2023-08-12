namespace FlpExporter.FlpExport
{
    public class FlpExportOptions
    {
        public FlpExportOptions(bool renderMp3, string outputFolder, string fl64Location)
        {
            RenderMp3 = renderMp3;
            this.outputFolder = outputFolder;
            this.fl64Location = fl64Location;
        }

        public bool RenderMp3 { get; set; }
        public string outputFolder { get; set; }
        public string fl64Location { get; set; }
    }
}
