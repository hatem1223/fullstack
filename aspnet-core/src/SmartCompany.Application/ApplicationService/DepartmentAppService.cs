using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using SmartCompany.DTO;
using SmartCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCompany.ApplicationService
{
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDTO>, IDepartmentAppService
    {
        public DepartmentAppService(IRepository<Department, int> repository) : base(repository)
        {
        }

        public IEnumerable<DepartmentDTO> SearchByDepartment(string keyword)
        {
            var list = Repository.GetAll().Where(x => x.Departname == keyword).Select(x=>new DepartmentDTO {  Departname=x.Departname, Id=x.Id}).ToList();
            return list;
        }
    }
}
