using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccination;

namespace Vaccination
{
    public class BeneficiaryDetails
    {
        private static int _beneficiaryId = 1001;

        private List<VaccinationDetails> _vaccinations = new List<VaccinationDetails>();
        public BeneficiaryDetails()
        {
            _beneficiaryId++;
            RegisterNo = _beneficiaryId;
        }
        public string Name { get; set; }
        public int RegisterNo { get; private set; }

        public long PhoneNo { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
       


        public void AddvacinationDetails(VaccinationDetails vaccination)
        {
            if (_vaccinations.Count == 0)
            {
                vaccination.Dosage = 1;
            }
            else if(_vaccinations.Count == 1)
            {
                vaccination.Dosage = 2;
            }
            _vaccinations.Add(vaccination);
        }
        public List<VaccinationDetails> GetVaccinations() 
            {
             return _vaccinations;
            }
    public DateTime GetNextVaccinationDate()
    {
            if (_vaccinations.Count == 2)
            {
                Console.WriteLine("You have completed the vaccination course");
                
            }
            else if (_vaccinations.Count == 1)
            {
                VaccinationDetails vaccination = _vaccinations[0];
                return vaccination.VaccinatedDate.AddDays(30);
            }
            return DateTime.Today;
    }
    







        
       
        

    }

    public enum GenderType
    {
        male = 1,
        female,
        others,
    }
}
