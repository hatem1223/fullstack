using Abp.Application.Services;
using SmartCompany.DTO;
using SmartCompany.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCompany.ApplicationService
{
  public  interface IEmployeeAppService
    {
       IEnumerable<EmployeeDTO> SearchByName(String keyword);
        IEnumerable<Employee> SearchingByName(String keyword);
    }
}
