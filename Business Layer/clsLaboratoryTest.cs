using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsLaboratoryTest
    {

        public int TestID { get; set; }
        public string TestTitle { get; set; }
        
        public float TestFees { get; set; }
        public string Description { get; set; }


        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsLaboratoryTest()
        {
            TestID = -1;
            TestTitle = string.Empty;
            Description = string.Empty;
            TestFees = -1;
            _Mode = enMode.AddNew;

        }

        private clsLaboratoryTest(int TestID, string TestTitle, 
            float TestFees, string Description)
        {
            this.TestID = TestID;
            this.TestTitle = TestTitle;
            this.TestFees = TestFees;
            this.Description = Description;

            _Mode = enMode.Update;

        }

        public static clsLaboratoryTest FindTestInfo(int TestID)
        {

            string TestTitle = "";
            float TestFees = -1;
            string Description = "";
          
        



            if (clsLaboratoryTestData.FindTest(TestID, ref TestTitle,
                  ref TestFees, ref Description))
            {
                return new clsLaboratoryTest(TestID, TestTitle,
                    TestFees, Description);
            }
            else { return null; }
        }




        public static DataTable GetAllTests()
        {

            return clsLaboratoryTestData.GetAllTestsData();
        }


        bool _AddNew()
        {
            this.TestID = clsLaboratoryTestData.AddNewTest(this.TestTitle,
                this.TestFees, this.Description);
                

            return this.TestID != -1;


        }
        bool _Update()
        {
            return clsLaboratoryTestData.UpdateTest(this.TestID, this.TestTitle, this.TestFees,
                this.Description
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

        public static bool DeleteTest(int TestID)
        {
            return clsLaboratoryTestData.DeleteTestData(TestID);

        }

    }
}
