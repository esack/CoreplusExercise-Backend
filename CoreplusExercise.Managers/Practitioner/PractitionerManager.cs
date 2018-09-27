using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreplusExercise.Accessor.Practitioner;
using CoreplusExercise.Managers.Practitioner.DTOs;

namespace CoreplusExercise.Managers.Practitioner
{
    public class PractitionerManager : IPractitionerManager
    {
        public readonly IPractitionerAccessor _practitionerAccessor;
        public readonly IMapper _mapper;

        public PractitionerManager(IPractitionerAccessor practitionerAccessor, IMapper mapper)
        {
            _practitionerAccessor = practitionerAccessor;
            _mapper = mapper;
        }

        public async Task<List<PractitionerBaseDTO>> GetPractitionersAsync(long fromUnixTimeMilliseconds, long toUnixTimeMilliseconds)
        {
            var dateFrom = DateTimeOffset.FromUnixTimeMilliseconds(fromUnixTimeMilliseconds).UtcDateTime;
            var dateTo = DateTimeOffset.FromUnixTimeMilliseconds(toUnixTimeMilliseconds).UtcDateTime;

            var practitioners = await _practitionerAccessor.GetPractitionersAsync(dateFrom, dateTo);

            return _mapper.Map<List<PractitionerBaseDTO>>(practitioners);
        }

        public async Task<PractitionerDTO> GetPractitionerAsync(Guid id, long fromUnixTimeMilliseconds, long toUnixTimeMilliseconds)
        {
            var dateFrom = DateTimeOffset.FromUnixTimeMilliseconds(fromUnixTimeMilliseconds).UtcDateTime;
            var dateTo = DateTimeOffset.FromUnixTimeMilliseconds(toUnixTimeMilliseconds).UtcDateTime;

            var practitioner = await _practitionerAccessor.GetPractitionerAsync(id, dateFrom, dateTo);

            return _mapper.Map<PractitionerDTO>(practitioner);
        }
    }
}
