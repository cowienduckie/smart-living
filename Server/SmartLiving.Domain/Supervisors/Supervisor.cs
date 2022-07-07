using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.RepositoryInterfaces;
using SmartLiving.Domain.Supervisors.Interfaces;
using SmartLiving.Library.Constants;
using SmartLiving.Library.DataTypes;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor : ISupervisor
    {
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        private readonly IAreaRepository _areaRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public Supervisor(
            IMemoryCache cache,
            IMapper mapper,
            IAreaRepository areaRepository,
            ICommandRepository commandRepository,
            IDeviceRepository deviceRepository,
            IHouseRepository houseRepository,
            IProfileRepository profileRepository,
            IScheduleRepository scheduleRepository)
        {
            _cache = cache;
            _mapper = mapper;
            _areaRepository = areaRepository;
            _commandRepository = commandRepository;
            _deviceRepository = deviceRepository;
            _houseRepository = houseRepository;
            _profileRepository = profileRepository;
            _scheduleRepository = scheduleRepository;
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