namespace Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Extensions;

public static class EnumerableExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }
}
