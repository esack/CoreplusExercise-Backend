using CoreplusExercise.Managers.Practitioner.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreplusExercise.Managers.Practitioner
{
    public interface IPractitionerManager
    {
        Task<List<PractitionerBaseDTO>> GetPractitionersAsync(DateTime dateFrom, DateTime dateTo);
        Task<PractitionerDTO> GetPractitionerAsync(Guid id);
    }
}
