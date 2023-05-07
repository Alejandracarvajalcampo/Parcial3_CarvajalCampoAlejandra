using WashingCarDB.Enums;
using WashingCarDB.Helper;

namespace WashingCarDB.DAL.Entities
{
    public class Seeder
    {
        private readonly DatabaseContext _context;
        private readonly IUserHelper _userHelper;

        public Seeder(DatabaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("aleja","carvajal","1215445", "admin_role@yopmail.com", UserType.Admin);
            await PopulateUserAsync("marta", "campo", "454545", "client_role@yopmail.com", UserType.Client);
            await PopulateUserAsync("Paola", "velazques", "215", "client_role_2@yopmail.com", UserType.Client);

            await _context.SaveChangesAsync();
        }
        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service { Name = "Lavada simple", Price = 25000 });
                _context.Services.Add(new Service { Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Service { Name = "Lavada + Aspirada de Cojinería", Price = 30000 });
                _context.Services.Add(new Service { Name = "Lavada Full:", Price = 65000 });
                _context.Services.Add(new Service { Name = "Lavada en seco del Motor", Price = 80000 });
                _context.Services.Add(new Service { Name = "Lavada Chasis", Price = 90000 });
            }

        }
        private async Task PopulateRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Client.ToString());

        }
        private async Task PopulateUserAsync(
            string firstName,
            string lastName,
            string document,
            string email,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    FirstName= firstName,
                    LastName= lastName,
                    Document= document,
                    UserName = email,
                    Email = email,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }
    }
}

