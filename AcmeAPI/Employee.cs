using System;
using System.Collections.Generic;

namespace AcmeAPI
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployeedDate { get; set; }
        public DateTime? Terminated { get; set; }

        public virtual Person Person { get; set; }
    }
}
