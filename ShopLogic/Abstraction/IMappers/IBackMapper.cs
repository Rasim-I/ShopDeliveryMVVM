using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Abstraction.IMappers
{
    public interface IBackMapper<TEntity, TModel>
    {
        TEntity ToEntity(TModel model);
    }
}
