using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace SuperAwesome.Api.Business
{
    public interface IProject : IBaseEntity<Domain.Project, int>
    {
    }
}