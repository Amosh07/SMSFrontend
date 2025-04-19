using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Identity;
using SMS.Service.Base;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class StudentService(IBaseService baseService) : IStudentService
    {
        public async Task<ResponseDto<StudentDetails?>?> GetAllStudentById(int periodAction)
        {
            var pathParameter = new List<string>
        {
                periodAction.ToString()
            };

            var response = await baseService.GetAsync<StudentDetails>(ApiEndpoints.Student.GetAllStudentById, pathParameter);

            return response;
        }
    }
}
