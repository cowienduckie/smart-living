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
        private readonly ICommandTypeRepository _commandTypeRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IHouseTypeRepository _houseTypeRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public Supervisor(
            IMemoryCache cache,
            IMapper mapper,
            IAreaRepository areaRepository,
            ICommandRepository commandRepository,
            ICommandTypeRepository commandTypeRepository,
            IDeviceRepository deviceRepository,
            IDeviceTypeRepository deviceTypeRepository,
            IHouseRepository houseRepository,
            IHouseTypeRepository houseTypeRepository,
            IProfileRepository profileRepository,
            IScheduleRepository scheduleRepository)
        {
            _cache = cache;
            _mapper = mapper;
            _areaRepository = areaRepository;
            _commandRepository = commandRepository;
            _commandTypeRepository = commandTypeRepository;
            _deviceRepository = deviceRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _houseRepository = houseRepository;
            _houseTypeRepository = houseTypeRepository;
            _profileRepository = profileRepository;
            _scheduleRepository = scheduleRepository;
        }

        #region Shared Methods
        private void SetCache<TEntity>(int id, TEntity product, string userId)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(
                    TimeSpan.FromSeconds(SystemConstants.CacheLifetimeSeconds));
            _cache.Set(string.Concat(nameof(TEntity), "-", id) + "-" + userId, product, cacheEntryOptions);
        }

        private TEntity GetCache<TEntity>(int id, string userId)
        {
            return _cache.Get<TEntity>(string.Concat(nameof(TEntity), "-", id) + "-" + userId);
        }

        public PagedList<TEntity> GetPagedList<TEntity>(IList<TEntity> items, int pageIndex, int pageSize)
        {
            var pagedList = new PagedList<TEntity>(_mapper.Map<IList<TEntity>>(items), pageIndex, pageSize);

            return pagedList;
        }
        #endregion
    }
}