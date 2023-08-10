using FlpExporter.Stages.Models;

namespace FlpExporter.Stages
{
    public class FlpRenderStage : IStage
    {
        private readonly FlpRenderOptions _options;

        public FlpRenderStage(FlpRenderOptions options)
        {
            _options = options;
        }
        public Task Run()
        {
            throw new NotImplementedException();
        }
    }
}
