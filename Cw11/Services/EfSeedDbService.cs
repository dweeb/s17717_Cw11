using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class EfSeedDbService : ISeedDbService
    {
        private readonly PharmacyDbContext _context;
        public EfSeedDbService(PharmacyDbContext context)
        {
            _context = context;
        }
        public int Seed()
        {
            int created = 0;
            if(_context.Doctors.FirstOrDefault() == null)
            {
                _context.Doctors.Add(new Doctor
                {
                    FirstName = "Jerzy",
                    LastName = "Lekarski",
                    Email = "jlek@lekarze.pl"
                });
                _context.Doctors.Add(new Doctor
                {
                    FirstName = "Henner",
                    LastName = "Schmidt",
                    Email = "hs@doktor.de"
                });
                _context.Doctors.Add(new Doctor
                {
                    FirstName = "Linda",
                    LastName = "Ludens",
                    Email = "lludens@emai.ly"
                });
                _context.SaveChanges();
                created += 3;
            }
            if(_context.Patients.FirstOrDefault() == null)
            {
                _context.Patients.Add(new Patient
                {
                    FirstName = "Sebastian",
                    LastName = "Kontuzjasz",
                    BirthDate = DateTime.ParseExact("1995-03-13", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                });
                _context.SaveChanges();
                created++;
            }
            if(_context.Medicaments.FirstOrDefault() == null)
            {
                _context.Medicaments.Add(new Medicament
                {
                    Name = "Hyperzine",
                    Description = "Synthetic adrenaline",
                    Type = "Stimulant"
                });
                _context.SaveChanges();
                created++;
            }
            if(_context.Prescriptions.FirstOrDefault() == null)
            {
                _context.Prescriptions.Add(new Prescription
                {
                    Doctor = _context.Doctors.First(),
                    Patient = _context.Patients.First(),
                    Date = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14)
                });
                _context.SaveChanges();
                created++;
            }
            if(_context.Prescription_Medicament.FirstOrDefault() == null)
            {
                _context.Prescription_Medicament.Add(new Prescription_Medicament
                {
                    Medicament = _context.Medicaments.First(),
                    Prescription = _context.Prescriptions.First(),
                    Dose = 10,
                    Details = "Take once per day"
                });
                _context.SaveChanges();
                created++;
            }
            return created;
        }
    }
}
