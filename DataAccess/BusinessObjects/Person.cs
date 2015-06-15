using System;

namespace NPOI.DataAccess.BusinessObjects
{
    public class Person
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}