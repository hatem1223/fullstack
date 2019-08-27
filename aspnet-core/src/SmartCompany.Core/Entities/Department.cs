using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCompany.Entities
{
   public class Department:Entity
    {
        public String Departname { get; set; }

        List<Employee> employees { set; get; }
    }
}
