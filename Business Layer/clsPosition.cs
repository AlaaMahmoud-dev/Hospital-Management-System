using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsPosition
    {
       
        public int PositionID { get; set ; }
        public string PositionTitle { get; set; }
        

        public clsPosition() 
        {
            PositionID = -1;
            PositionTitle = "";
        }

        clsPosition(int PositionID, string PositionTitle)
        {
            this.PositionID = PositionID;
            this.PositionTitle = PositionTitle;
        }
        public static clsPosition FindPositionInfoByID(int PositionID)
        {

            string PositionTitle = "";



            if (clsPositionData.FindPositionInfoByPositionID(PositionID, ref PositionTitle))
            {
                return new clsPosition(PositionID, PositionTitle);
            }
            else { return null; }
        }

        public static clsPosition FindPositionInfoByTitle(string PositionTitle)
        {

            int PositionID = -1;



            if (clsPositionData.FindPositionInfoByPositionTitle(ref PositionID, PositionTitle))
            {
                return new clsPosition(PositionID, PositionTitle);
            }
            else { return null; }
        }
        public static DataTable GetPositionsList()
        {
            return clsPositionData.GetPositionsList();
        }

    }
}
