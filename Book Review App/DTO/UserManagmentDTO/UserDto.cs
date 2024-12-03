namespace Book_Review_App.DTO.UserManagmentDTO
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
