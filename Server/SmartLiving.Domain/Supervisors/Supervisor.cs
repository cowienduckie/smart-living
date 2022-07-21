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
        private readonly IUserRepository _userRepository;

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
            IScheduleRepository scheduleRepository,
            IUserRepository userRepository)
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
            _userRepository = userRepository;
        }

        #region Shared Methods
        private void SetCache<TEntity>(int id, TEntity value, string userId)
        {
            var cacheEntryOptions =
                new MemoryCacheEntryOptions().SetSlidingExpiration(
                    TimeSpan.FromSeconds(SystemConstants.CacheLifetimeSeconds));
            var key = string.Concat(typeof(TEntity).FullName, "-", id) + "-" + userId;
            _cache.Set(key, value, cacheEntryOptions);
        }

        private TEntity GetCache<TEntity>(int id, string userId)
        {
            var key = string.Concat(typeof(TEntity).FullName, "-", id) + "-" + userId;

            return _cache.Get<TEntity>(key);
        }

        public PagedList<TEntity> GetPagedList<TEntity>(IList<TEntity> items, int pageIndex, int pageSize)
        {
            var pagedList = new PagedList<TEntity>(_mapper.Map<IList<TEntity>>(items), pageIndex, pageSize);

            return pagedList;
        }
        #endregion
    }
}