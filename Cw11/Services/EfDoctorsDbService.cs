using Cw11.Models;
using Cw11.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class EfDoctorsDbService : IDoctorsDbService
    {
        private readonly PharmacyDbContext _context;
        public EfDoctorsDbService(PharmacyDbContext context)
        {
            _context = context;
        }
        public Doctor AddDoctor(Doctor doc)
        {
            _context.Doctors.Add(doc);
            _context.SaveChanges();
            return doc;
        }

        public Doctor GetDoctor(int id)
        {
            return _context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor ModifyDoctor(int id, ModifyDoctorRequest req)
        {
            var doc = _context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();
            if (doc == null)
                return null;
            bool changed = false;
            if (req.FirstName != null)
            {
                doc.FirstName = req.FirstName;
                changed = true;
            }
            if (req.LastName != null)
            {
                doc.LastName = req.LastName;
                changed = true;
            }
            if (req.Email != null)
            {
                doc.Email = req.Email;
                changed = true;
            }
            if(changed)
                _context.SaveChanges();
            return doc;
        }

        public bool RemoveDoctor(int id)
        {
            var doc = _context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();
            if (doc == null)
                return false;
            _context.Doctors.Remove(doc);
            _context.SaveChanges();
            return true;
        }
    }
}
