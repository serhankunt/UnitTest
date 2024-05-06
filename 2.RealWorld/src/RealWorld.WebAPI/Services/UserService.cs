using RealWorld.WebAPI.Logging;
using RealWorld.WebAPI.Models;
using RealWorld.WebAPI.Repositories;

namespace RealWorld.WebAPI.Services;

public sealed class UserService(IUserRepository userRepository, ILoggerAdapter<UserService> logger) : IUserService
{
    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Tüm userlar getiriliyor.");
		try
		{
			return userRepository.GetAllAsync(cancellationToken);	
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "User listesini çekerken bir hatayla karşılaştık");
			throw;
		}
		finally
		{
			logger.LogInformation("Tüm user listesi çekildi");
		}
    }
}