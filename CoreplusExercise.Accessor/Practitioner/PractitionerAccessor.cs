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

        public async Task<PractitionerDTO> GetPractitionerAsync(Guid id)
        {
            var practitioner = await _context.Practitioners.Where(r => r.Id == id).Include(r => r.Appointments).SingleAsync();

            return _mapper.Map<PractitionerDTO>(practitioner);
        }

        public async Task<List<PractitionerBaseDTO>> GetPractitionersAsync(DateTime dateFrom, DateTime dateTo)
        {
            var query = from a in _context.Appointments
                        join p in _context.Practitioners on a.PractitionerId equals p.Id
                        where a.Date >= dateFrom && a.Date <= dateTo
                        group a by p into g
                        select _mapper.Map<PractitionerBaseDTO>(g);
                        //new PractitionerBaseDTO
                        //{
                        //    Id = g.Key.Id,
                        //    FirstName = g.Key.FirstName,
                        //    LastName = g.Key.LastName,
                        //    Cost = g.Sum(a => a.Cost),
                        //    Revenu = g.Sum(a => a.Revenu)
                        //};

            return await query.ToListAsync();
        }
    }
}
