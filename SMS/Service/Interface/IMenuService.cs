using SMS.Models.Base;
using SMS.Models.Requests.Menu;
using SMS.Models.Responses.Menu;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IMenuService : ITransientService
    {
        Task<ResponseDto<List<RoleMenuResponseDto>?>?> GetAllRoleMenus(Guid roleId);

        Task<ResponseDto<List<RoleMenuResponseDto>?>?> GetAllAssignedMenus();

        Task<ResponseDto<bool?>?> AssignRoleMenus(RoleMenuRequestDto menuRights);
    }
}
