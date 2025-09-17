using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsPerson
    {

        public int ID { get; set; }


        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public char Gendor { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


      

        public string FullName
        {
            get
            {

                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsPerson()
        {
            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 'M';
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
         
            _Mode = enMode.AddNew;

        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, char Gendor, string Address
            , string Phone, string Email)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
          

            _Mode = enMode.Update;

        }

        public static clsPerson FindPerson(int PersonID)
        {

            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            char Gendor = 'M';
            string Address = "";
            string Phone = "";
            string Email = "";
       

            if (clsPersonData.FindPerson(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address
                , ref Phone, ref Email))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email);
            }
            else { return null; }
        }



        public static clsPerson FindPerson(string NationalNo)
        {


            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            char Gendor = 'M';
            string Address = "";
            string Phone = "";
            string Email = "";
           

            if (clsPersonData.FindPerson(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address
                , ref Phone, ref Email))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email);
            }
            else { return null; }
        }

        public static DataTable PeopleList()
        {

            return clsPersonData.GetPeopleList();
        }

        //public static DataTable CountriesList()
        //{
        //    return clsPersonData.GetCountriesList();
        //}

        //public static string GetCountryNameByCountryID(int CountryID)
        //{
        //    return clsPersonData.GetCountryName(CountryID);
        //}

        //public static int GetCountryID(string CountryName)
        //{
        //    return clsPersonData.GetCountryID(CountryName);
        //}
        bool _AddNew()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gendor, this.Address, this.Phone,
                this.Email
                );

            return this.ID != -1;


        }
        bool _Update()
        {
            return clsPersonData.UpdatePerson(this.ID, this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email
                );
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();


            }
            return false;
        }
        public static DataTable NationalNoList()
        {
            return clsPersonData.GetAllNationalNumbers();
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);

        }

        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            return clsPersonData.IsPersonExistByNationalNo(NationalNo);
        }




    }
   
}
