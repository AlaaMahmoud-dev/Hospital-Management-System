using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsSpecialization
    {



        public int SpecializationID { get; set; }
        public string SpecializationTitle { get; set; }


        public clsSpecialization()
        {
            SpecializationID = -1;
            SpecializationTitle = "";
        }

        clsSpecialization(int SpecializationID, string SpecializationTitle)
        {
            this.SpecializationID = SpecializationID;
            this.SpecializationTitle = SpecializationTitle;
        }
        public static clsSpecialization FindInfoBySpecializationID(int SpecializationID)
        {

            string SpecializationTitle = "";



            if (clsSpecializationData.FindSpecializationInfoBySpecializationID(SpecializationID, ref SpecializationTitle))
            {
                return new clsSpecialization(SpecializationID, SpecializationTitle);
            }
            else { return null; }
        }

        public static clsSpecialization FindInfoBySpecializationTitle(string SpecializationTitle)
        {

            int SpecializationID = -1;



            if (clsSpecializationData.FindSpecializationInfoBySpecializationTitle(ref SpecializationID, SpecializationTitle))
            {
                return new clsSpecialization(SpecializationID, SpecializationTitle);
            }
            else { return null; }
        }
        public static DataTable GetSpecializationsList()
        {
            return clsSpecializationData.GetSpecializationsList();
        }


    }
}
