using SMS.Service.Dependency;

namespace SMS.Service.Manager
{
    public interface IFileManager : ITransientService
    {
        Task<string> RenderSvgContent(string path, string fileName);
    }
}
