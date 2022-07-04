using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;
using SmartLiving.Library.Constants;
using SmartLiving.Library.DataTypes;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor : ISupervisor
    {
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public Supervisor(
            IMemoryCache cache,
            IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;
        }

        #region Shared Methods
        private void SetCache<TEntity>(int id, TEntity product)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(
                    TimeSpan.FromSeconds(SystemConstants.CacheLifetimeSeconds));
            _cache.Set(string.Concat(nameof(TEntity), "-", id), product, cacheEntryOptions);
        }

        private TEntity GetCache<TEntity>(int id)
        {
            return _cache.Get<TEntity>(string.Concat(nameof(TEntity), "-", id));
        }

        public PagedList<TEntity> GetPagedList<TEntity>(IList<TEntity> items, int pageIndex, int pageSize)
        {
            var pagedList = new PagedList<TEntity>(_mapper.Map<IList<TEntity>>(items), pageIndex, pageSize);

            return pagedList;
        }
        #endregion
    }
}