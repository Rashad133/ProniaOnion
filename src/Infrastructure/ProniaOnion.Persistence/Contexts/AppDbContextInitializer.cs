using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Domain.Enums;

namespace ProniaOnion.Persistence.Contexts
{
    public class AppDbContextInitializer
    {
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AppDbContextInitializer(RoleManager<IdentityRole> roleManager
            ,UserManager<AppUser> userManager
            ,IConfiguration configuration
            ,AppDbContext db
            )
        {
            _db = db;
            _roleManager = roleManager;
            _userManager= userManager;
            _configuration= configuration;
        }
        public async Task InitializeDbContext()
        {
            await _db.Database.MigrateAsync();
        }

        public async Task CreateRoleAsync()
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if(await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name=role.ToString()});
                }
            }
        }

        public async Task InitializeAdmin()
        {
            AppUser admin = new AppUser
            {
                Name= "Admin",
                Surname = "Admin",
                Email = _configuration["AdminSettings:Email"],
                UserName = _configuration["AdminSettings:Username"]
            };

            await _userManager.CreateAsync(admin, _configuration["AdminSettings:Password"]);
            await _userManager.AddToRoleAsync(admin,UserRole.Admin.ToString());
        }
    }
}
