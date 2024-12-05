using Book_Review_App.Data;
using Book_Review_App.Models.UserManagment;

namespace Book_Review_App
{
    public class UserSeed
    {
        private readonly DataContextUser _dataContext;

        public UserSeed(DataContextUser context)
        {
            _dataContext = context;
        }

        public void SeedDataContextUser()
        {
           /* if (!_dataContext.Users.Any())
            {
                //Roles
                var adminRole = new Role { Name = "Admin" };
                var contentReviewerRole = new Role { Name = "ContentReviewer" };
                var visitatorRole = new Role { Name = "Visitator" };

                _dataContext.Roles.AddRange(adminRole, contentReviewerRole, visitatorRole);


            }*/
        }
    }
}
