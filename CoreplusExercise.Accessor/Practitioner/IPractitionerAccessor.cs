using CoreplusExercise.Accessor.Practitioner.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreplusExercise.Accessor.Practitioner
{
    public interface IPractitionerAccessor
    {
        Task<List<PractitionerBaseDTO>> GetPractitionersAsync(DateTime dateFrom, DateTime dateTo);
        Task<PractitionerDTO> GetPractitionerAsync(Guid id, DateTime dateFrom, DateTime dateTo);
    }
}
