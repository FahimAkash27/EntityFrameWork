using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreA
{
    public class StudentInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double FineAmount { get; set; }

        public List<StudentBook> StudentIssuedBooks { get; set; }
    }
}
