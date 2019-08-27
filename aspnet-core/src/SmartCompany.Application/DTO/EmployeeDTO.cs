using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartCompany.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCompany.DTO
{
    [AutoMap(typeof(Employee))]
   public class EmployeeDTO: EntityDto
    {
        public double? Salary { set; get; }
        public string Name { set; get; }

        public string departmentDepartname { get; set; }
        public int? Dno { set; get; }
    }
}
