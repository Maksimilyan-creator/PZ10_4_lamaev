using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ10_4_lamaev
{
     class Status_notes
    {
        public string Name { get; set; }
        public Status status { get; set; }
        public Status_notes(string name, Status st)
        {
            Name = name;
            status = st;
        }
    }
    public enum Status
    {
        Active,
        completed
    }
}
