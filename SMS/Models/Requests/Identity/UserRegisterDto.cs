namespace SMS.Models.Requests.Identity
{
    public class UserRegisterDto : RegisterDto
    {
            public Guid RoleId { get; set; }
    }
}
