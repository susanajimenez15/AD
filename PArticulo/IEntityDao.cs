using System;

using PArticulo;

namespace Org.InstitutoSerpis.Ad
{
	public interface IEntityDao<TEntity>
	{
		TEntity Load(object id);
	}
}

