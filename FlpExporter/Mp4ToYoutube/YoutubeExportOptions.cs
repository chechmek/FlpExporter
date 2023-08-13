using System.Text.Json.Serialization;

namespace FlpExporter.Mp4ToYoutube
{
    public class YoutubeExportOptions
    {
        [JsonRequired]
        public string VidFolder { get; set; }
        // date, channel name, video name, description
    }
}
