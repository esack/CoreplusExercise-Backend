using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreplusExercise.Accessor.Practitioner.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreplusExercise.Accessor.Practitioner
{
    public class PractitionerAccessor : IPractitionerAccessor
    {
        private readonly PractitionerContext _context;
        private readonly IMapper _mapper;

        public PractitionerAccessor(PractitionerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PractitionerDTO> GetPractitionerAsync(Guid id, DateTime dateFrom, DateTime dateTo)
        {
            var query = await (from p in _context.Practitioners
                        join a in _context.Appointments on p.Id equals a.PractitionerId
                        where p.Id == id && a.Date >= dateFrom && a.Date <= dateTo
                        select new { Practitioner = p, Appointment = a }).ToListAsync();

            var practitioner = _mapper.Map<PractitionerDTO>(query[0].Practitioner);
            practitioner.Appointments = _mapper.Map<List<AppointmentDTO>>(query.Select(r => r.Appointment).ToList());

            return practitioner;
        }

        public async Task<List<PractitionerBaseDTO>> GetPractitionersAsync(DateTime dateFrom, DateTime dateTo)
        {
            var query = from a in _context.Appointments
                        join p in _context.Practitioners on a.PractitionerId equals p.Id
                        where a.Date >= dateFrom && a.Date <= dateTo
                        group a by p into g
                        select _mapper.Map<PractitionerBaseDTO>(g);                   

            return await query.ToListAsync();
        }
    }
}
