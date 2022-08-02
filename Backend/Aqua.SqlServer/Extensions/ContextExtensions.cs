using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.SqlServer;

namespace Aqua.SqlServer.Extensions;

public static class ContextExtensions
{
    public static AppUser CreateAppUserIfNotExist(this DataContext context, string userId)
        => context.AppUsers.FirstOrDefault(user => user.UserId == userId) ?? context.AppUsers.Add(new AppUser { UserId = userId }).Entity;
}
