using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Requests.Menu;
using SMS.Models.Responses.Menu;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class MenuService(IBaseService baseService) : IMenuService
    {
        public async Task<ResponseDto<List<RoleMenuResponseDto>?>?> GetAllRoleMenus(Guid roleId)
        {
            var pathParameter = new List<string>
        {
            roleId.ToString()
        };

            var response = await baseService.GetAsync<List<RoleMenuResponseDto>?>(ApiEndpoints.RoleRights.GetAllRoleMenus, pathParameter);

            return response;
        }

        public async Task<ResponseDto<List<RoleMenuResponseDto>?>?> GetAllAssignedMenus()
        {
            var response = await baseService.GetAsync<List<RoleMenuResponseDto>?>(ApiEndpoints.RoleRights.GetAllAssignedMenus);

            return response;
        }

        public async Task<ResponseDto<bool?>?> AssignRoleMenus(RoleMenuRequestDto menuRights)
        {
            var jsonRequest = JsonSerializer.Serialize(menuRights);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.RoleRights.AssignRoleMenus, content);

            return response;
        }
    }
}
