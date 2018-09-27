using CoreplusExercise.Accessor.Mock.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreplusExercise.Accessor.Mock
{
    public interface IMockAccessor
    {
        List<AppointmentDTO> GetAppointmentData(int count);
        List<PractitionerDTO> GetPractitionerData(int count);
    }
}