using System.Collections.Generic;

namespace AdminEntities
{
    public class UserDTO
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string ProfilePicture { get; set; }

        }

        public interface IUser
        {
            List<UserDTO> Read();
            UserDTO ById(int id);
            bool Create(UserDTO user);
            bool Update(UserDTO user);
            bool Delete(UserDTO user);

        }
}