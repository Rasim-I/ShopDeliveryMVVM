using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Abstraction.IMappers
{
    public interface IMapper<TEntity, TModel> : IBackMapper<TEntity, TModel>
    {
        TModel ToModel(TEntity entity);
    }
}
