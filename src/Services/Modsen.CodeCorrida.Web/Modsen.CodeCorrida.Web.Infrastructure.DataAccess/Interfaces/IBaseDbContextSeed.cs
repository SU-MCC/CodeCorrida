using Microsoft.AspNetCore.Identity;

namespace Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Interfaces;

public interface IBaseDbContextSeed
{
    void Migrate();
    
    void EnsureCreated();
    
    Task SeedAsync(CancellationToken cancellationToken = default);
    
    //Task SeedSuperUserAsync(UserManager<User> userManager, CancellationToken cancellationToken = default);
}
