using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAwesome.Api.Data;
using SuperAwesome.Api.Domain;

namespace SuperAwesome.Api.Business
{
    public abstract class BaseEntity<T, TId> : IBaseEntity<T, TId>
        where T : BaseDomain<TId>
    {
        protected DbContext Context { get; private set; }

        protected BaseEntity(ApiDbContext context)
        {
            Context = context;
        }

        //public virtual Task<List<T>> GetAll()
        //{
        //    return Context.Set<T>().ToListAsync();
        //}
        public virtual Task<List<T>> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();

            query = GetAllWhere(query);

            return query.ToListAsync();
        }

        protected virtual IQueryable<T> GetAllWhere(IQueryable<T> query)
        {
            return query;
        }

        protected virtual async Task<T> GetByIdQuery(int id)
        {
            return await Context.Set<T>()
                                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<T> GetById(int id)
        {
            var project = await GetByIdQuery(id);

            if (project == null)
            {
                throw new EntityNotFoundException();
            }

            return project;
        }

        public virtual async Task Update(int id, T project)
        {
            Context.Entry(project).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    throw new EntityNotFoundException();
                }
                throw;
            }
        }

        public virtual async Task Add(T project)
        {
            Context.Set<T>().Add(project);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<T> Delete(int id)
        {
            var project = await Context.Set<T>().FindAsync(id);
            if (project == null)
            {
                throw new EntityNotFoundException();
            }

            Context.Set<T>().Remove(project);
            await Context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return Context.Set<T>().Any(e => e.Id.Equals(id));
        }
    }
}