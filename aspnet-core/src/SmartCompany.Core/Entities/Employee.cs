using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartCompany.Entities
{
   public class Employee:Entity
    {
        public double Salary { set; get; }
        public string Name { set; get; }

       
        public int Dno { set; get; }

        [ForeignKey("Dno")]
        public Department department { set; get; }

    }
}
