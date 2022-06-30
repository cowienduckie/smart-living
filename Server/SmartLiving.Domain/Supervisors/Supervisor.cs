using System;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SmartLiving.Domain.Supervisors.Interfaces;
using SmartLiving.Library.Constants;

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

        #endregion
    }
}