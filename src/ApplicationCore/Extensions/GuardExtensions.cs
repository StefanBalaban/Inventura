using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Inventura.ApplicationCore.Entities.UserAggregate;
using Inventura.ApplicationCore.Exceptions;
using Inventura.ApplicationCore.Helpers;

namespace Inventura.ApplicationCore.Extensions
{
    public static class BasketGuards
    {
        public static void DuplicateContactInfo(this IGuardClause guardClause,
            string contact,
            IReadOnlyCollection<UserContactInfo> userContactInfos)
        {
            if (userContactInfos.Any(x => x.Contact == contact))
                throw new DuplicateContactInfoException();
        }

        public static void EntityNotFound(this IGuardClause guardClause,
            object entity,
            string name)
        {
            if (entity == null)
                throw new EntityNotFoundException(name);
        }

        public static void ModelStateIsInvalid(this IGuardClause guardClause,
            object model,
            string name)
        {
            new ModelStateValidationHelper().ValidateModelState(model, name);
        }

    }
}