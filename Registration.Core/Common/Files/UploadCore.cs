using Microsoft.AspNetCore.Http;

namespace Registration.Core.Common.Files
{
    public class UploadCore
    {
        private static IHttpContextAccessor _context;

        public UploadCore(IHttpContextAccessor context)
        {
            _context = context;
        }
        public string GetBaseUrl()
        {
            var request = _context.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}";
            return baseUrl;
        }
    }
}
