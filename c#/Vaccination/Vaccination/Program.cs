using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccination;


namespace Vaccination
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BeneficiaryDetails> beneficiaries = new List<BeneficiaryDetails>();
            int opinion;
            do
            {
                Console.WriteLine("============== Vaccination Registeration and Details==============");
                Console.WriteLine();
                Console.WriteLine("Select your option \n1.Register\n2.Vaccinate\n3.Break");
                opinion = GetInput();


                switch (opinion)
                {
                    case 1:
                        AddBeneficiary(beneficiaries);
                        break;
                    case 2:
                        Vaccinate(beneficiaries);
                        break;
                    case 3:
                        break;
                }
            } while (opinion != 4);
        }
        // Adding beneficiary details for vaccination
        private static void AddBeneficiary(List<BeneficiaryDetails> beneficiaries)
        {
            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Age:");
            int age =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter the Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the  gender option \n1.Male\n2.Female\n3.Others:");
             int gender = GetInput();
            Console.WriteLine("Enter the Phone number:");
            long phoneNumber = long.Parse(Console.ReadLine());
            BeneficiaryDetails beneficiary = new BeneficiaryDetails();
            beneficiary.Name = name;
            beneficiary.PhoneNo = phoneNumber;
            beneficiary.Age = age;
            beneficiary.Gender = (GenderType) gender;
            beneficiary.Address = address;
            beneficiaries.Add(beneficiary);
            Console.WriteLine("Thank you for ypur Registeration. your Registeration Id is {0}", beneficiary.RegisterNo);
            Console.WriteLine("=================================================================");
            
            VaccinationDetails vaccination = new VaccinationDetails();



        }
        // Vaccination Details
        private static void Vaccinate(List<BeneficiaryDetails> beneficiaries)
        {
            Console.WriteLine("Please enter the Register number:");
            int regestrationNumber= GetInput();
            BeneficiaryDetails registeredBeneficiary = null;
            foreach (BeneficiaryDetails beneficiary in beneficiaries)
            {
                if(beneficiary.RegisterNo== regestrationNumber)
                {
                    registeredBeneficiary = beneficiary;
                    break;
                }
            }
            if (registeredBeneficiary != null)
            {
                Console.WriteLine("Select your opinion\n1.Take vaccination\n2.Vaccination history\n3.Next due date\n4.Exit ");
                int opinion= GetInput();
                switch (opinion)
                {
                    case 1:
                        if (registeredBeneficiary.GetVaccinations().Count <= 1)
                        {
                            int vaccinetype = 0;
                            if (registeredBeneficiary.GetVaccinations().Count == 1)
                            {
                                bool validVaccine = false;
                                do
                                {
                                    Console.WriteLine(" Select vaccine type:\n1.{0}\n2.{1}\n3.{2}", VaccinationType.Covaxin.ToString(), VaccinationType.CovidShield.ToString(), VaccinationType.Sputnik.ToString());
                                    if ((int)registeredBeneficiary.GetVaccinations()[0].Vaccine == vaccinetype)
                                    {
                                        validVaccine = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter already vaccinated type :");

                                    }
                                } while (validVaccine == false);

                            }
                            else
                            {
                                Console.WriteLine(" Select vaccine type:\n1.{0}\n2.{1}\n3.{2}", VaccinationType.Covaxin.ToString(), VaccinationType.CovidShield.ToString(), VaccinationType.Sputnik.ToString());
                                vaccinetype= GetInput(); 
                            }
                            Console.WriteLine("Vaccinated Date ;");
                           DateTime vaccinatedDate =DateTime.Parse( Console.ReadLine());
                            VaccinationDetails vaccination = new VaccinationDetails();
                            vaccination.Vaccine = (VaccinationType)vaccinetype;
                            vaccination.VaccinatedDate = vaccinatedDate;
                            registeredBeneficiary.AddvacinationDetails(vaccination);
                        }
                        else
                        {
                            Console.WriteLine("You have already completed the vaccination");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Vccination details are follows");
                        Console.WriteLine("Register number is {0}", registeredBeneficiary.RegisterNo);
                        Console.WriteLine("Name is {0}", registeredBeneficiary.Name);
                        foreach (VaccinationDetails vaccination1 in registeredBeneficiary.GetVaccinations())
                        {
                            Console.WriteLine("Dose {0}", vaccination1.Dosage);
                            Console.WriteLine("Vaccine type : {0}", vaccination1.Vaccine.ToString());
                            Console.WriteLine("Vacccination Date : {0}", vaccination1.VaccinatedDate.ToString());
                            Console.WriteLine();


                        }
                        break;
                    case 3:
                        if (registeredBeneficiary.GetNextVaccinationDate() != DateTime.Today)
                        {
                            Console.WriteLine("The next  vaccination due date is {0}", registeredBeneficiary.GetNextVaccinationDate().ToString());
                        }
                        break;


                }
            }
            else
            {
                Console.WriteLine(" Please first register for Vaccination");
            }


        }
        // Getting input Method for exception
        private static int GetInput()
        {
            bool validInput = false;
            while (validInput ==false)
            {
                try
                {
                    if(int.TryParse(Console.ReadLine(),out int input))
                    {
                        validInput = true;
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("Please enter the valid input");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Please enter the valid input");
                    validInput = false;
                }
            }
            return 0;
        }

        
    }
    // Decalaring Gender in Enum
    public enum VaccinationType
    {
        Covaxin = 1,
        CovidShield,
        Sputnik
    }
   
}
