﻿using System;

namespace AcmeEntities.ViewModels
{
    public class EmployeeCreate
    {
        public int EmployeeeId { get; set; }
        public string EmployeeNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmployeedDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? Terminated { get; set; }
    }
}

