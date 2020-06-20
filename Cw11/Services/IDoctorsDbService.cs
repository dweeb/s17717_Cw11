using Cw11.Models;
using Cw11.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public interface IDoctorsDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doc);
        public Doctor ModifyDoctor(int id, ModifyDoctorRequest req);
        public bool RemoveDoctor(int id);
    }
}
