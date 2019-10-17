using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreA
{
    public class BookInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Edition { get; set; }

        public string Barcode { get; set; }

        public int Count { get; set; }

    }
}
