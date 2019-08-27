using SmartCompany.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCompany.ApplicationService
{
   public interface IDepartmentAppService
    {
        IEnumerable<DepartmentDTO> SearchByDepartment(String keyword);
    }
}
