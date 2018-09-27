using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreplusExercise.Accessor.Mock.DOs;
using CoreplusExercise.Accessor.Mock.DTOs;
using RestSharp;

namespace CoreplusExercise.Accessor.Mock
{
    public class MockAccessor : IMockAccessor
    {
        private readonly IMapper _mapper;
        private readonly RestClient _restClient;

        public MockAccessor(IMapper mapper)
        {
            _mapper = mapper;
            _restClient = new RestClient("https://my.api.mockaroo.com");

        }

        public List<AppointmentDTO> GetAppointmentData(int count)
        {
            RestRequest request = new RestRequest($"server_appointments.json?key=b4d3dca0&count={count}", Method.GET);

            var response = _restClient.Execute<List<AppointmentDO>>(request);

            return _mapper.Map<List<AppointmentDTO>>(response.Data);
        }

        public List<PractitionerDTO> GetPractitionerData(int count)
        {
            RestRequest request = new RestRequest($"server_practitioner.json?key=b4d3dca0&count={count}", Method.GET);

            var response = _restClient.Execute<List<PractitionerDO>>(request);

            return _mapper.Map<List<PractitionerDTO>>(response.Data);
        }
    }
}
