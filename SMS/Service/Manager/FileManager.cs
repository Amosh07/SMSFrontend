
using SMS.Service.HTTP;
using SMS.Service.Interface;

namespace SMS.Service.Manager
{
    public class FileManager(ISnackbarService snackbarService, IConfiguration configuration, LocalHttpClient localHttpClient) : IFileManager
    {
        private readonly string[] _imageExtensions = [".jpg", ".jpeg", ".png"];
        private readonly string[] _resourceExtensions = [".jpg", ".jpeg", ".png", ".pdf", ".gif", ".svg"];
        public async Task<string> RenderSvgContent(string path, string fileName)
        {
            try
            {
                var svgFilePath = Path.Combine(path, fileName);

                return await localHttpClient.HttpClient.GetStringAsync(svgFilePath);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
