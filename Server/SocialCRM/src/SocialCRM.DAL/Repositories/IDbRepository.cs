using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SocialCRM.DAL.Entities;

namespace SocialCRM.DAL.Repositories
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T: class, IEntity;
        IQueryable<T> Get<T>() where T: class, IEntity;
        IQueryable<T> GetAll<T>() where T : class, IEntity;
        Task<Guid> Add<T>(T newEntity) where T: class, IEntity;
        Task Delete<T>(T entity) where T: class, IEntity;
        Task Update<T>(T entity) where T: class, IEntity;
        Task SaveChanges();
    }
}