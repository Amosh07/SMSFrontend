using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Identity;
using SMS.Service.Base;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class TeacherService(IBaseService baseService) : ITeacherService
    {
        public async Task<ResponseDto<TeacherDetails?>?> GetAllTeacherById(int periodAction)
        {
            var pathParameter = new List<string>
        {
                periodAction.ToString()
            };

            var response = await baseService.GetAsync<TeacherDetails>(ApiEndpoints.Teacher.GetAllTeacherById, pathParameter);

            return response;
        }
    }
}
