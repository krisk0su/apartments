using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentsAPI.Services.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public List<TEntity> Get();

        public TEntity Get(string id);

        public TEntity Create(TEntity entity);

        public void Update(string id, TEntity entityIn);
        public void Remove(TEntity entityIn);

        public void Remove(string id);
    }
}
