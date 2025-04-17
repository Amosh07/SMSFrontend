using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Exam;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class ExamService(IBaseService baseService) : IExamService
    {
        public async Task<ResponseDto<bool?>?> AddExam(Models.Requests.Exam.InsertExamDto insertExam)
        {
            var jsonRequest = JsonSerializer.Serialize(insertExam);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.Exam.AddExam, content);

            return response;
        }

        public async Task<ResponseDto<List<GetExamDetailDto>?>?> GetAllExamDetails()
        {
            var response = await baseService.GetAsync<List<GetExamDetailDto>?>(ApiEndpoints.Exam.GetAllExamDetails);

            return response;
        }
    }
}
