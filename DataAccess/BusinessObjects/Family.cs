using System.Collections.Generic;

namespace NPOI.DataAccess.BusinessObjects
{
    public class Family
    {
        public int FamilyID { get; set; }

        public int MomID { get; set; }
        public Person Mom { get; set; }

        public int DadID { get; set; }
        public Person Dad { get; set; }

        public List<Person> Kids { get; set; } 

    }
}

