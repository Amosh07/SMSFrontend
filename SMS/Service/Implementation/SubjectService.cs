using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Subject;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class SubjectService(IBaseService baseService) : ISubjectService
    {
        public async Task<ResponseDto<bool?>?> AddSubject(Models.Requests.Subject.InsertSubjectDto insertSubject)
        {
            var jsonRequest = JsonSerializer.Serialize(insertSubject);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.Subject.AddSubject, content);

            return response;
        }

        public async Task<ResponseDto<List<GetSubjectDetailDto>?>?> GetAllSubjectDetails()
        {
            var response = await baseService.GetAsync<List<GetSubjectDetailDto>?>(ApiEndpoints.Subject.GetAllSubjectDetails);

            return response;
        }
    }
}
