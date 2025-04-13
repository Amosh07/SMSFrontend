using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Requests.Result;
using SMS.Models.Responses.Result;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class ResultService(IBaseService baseService) : IResultService
    {
        public async Task<ResponseDto<bool?>?> AddResult(InsertResultDto insertResult)
        {
            var jsonRequest = JsonSerializer.Serialize(insertResult);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.Result.AddResult, content);

            return response;
        }

        public async Task<ResponseDto<List<GetResultDetailDto>?>?> GetAllResultDetails()
        {
            var response = await baseService.GetAsync<List<GetResultDetailDto>?>(ApiEndpoints.Result.GetAllResultDetails);

            return response;
        }
    }
}
