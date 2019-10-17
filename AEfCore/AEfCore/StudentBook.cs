using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreA
{
    public class StudentBook
    {
        public int StudentId { get; set; }

        public StudentInfo StudentInfo { get; set; }

        public int BookInfoId { get; set; }

        public BookInfo BookInfo { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool Returned { get; set; }

        public int Id { get; set; }

    }
}
