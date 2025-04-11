using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Requests.Class;
using SMS.Models.Requests.Identity;
using SMS.Models.Responses.Class;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class ClassService(IBaseService baseService) : IClassService
    {
        public async Task<ResponseDto<bool?>?> AddClass(InsertClassDto InsertClass)
        {
            var jsonRequest = JsonSerializer.Serialize(InsertClass);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.Class.AddClass, content);

            return response;
        }

        public async Task<ResponseDto<List<GetClassDetailDto>?>?> GetAllClassDetails()
        {
            var response = await baseService.GetAsync<List<GetClassDetailDto>?>(ApiEndpoints.Class.GetAllClassDetails);

            return response;
        }
    }
}
