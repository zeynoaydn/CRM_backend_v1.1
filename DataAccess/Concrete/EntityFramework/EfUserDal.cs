using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework;
using System.Linq;
using Core.Concrete;
using Core.Abstract.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CrmContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new CrmContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.Id == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
            }
        }
    }
}
