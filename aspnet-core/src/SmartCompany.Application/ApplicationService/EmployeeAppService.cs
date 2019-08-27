using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SmartCompany.Authorization;
using SmartCompany.DTO;
using SmartCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCompany.ApplicationService
{
    [AbpAuthorize(PermissionNames.Pages_Employees)]
    // public class EmployeeAppService : CrudAppServiceBase<Employee,EmployeeDTO>,IEmployeeAppService
    public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDTO , int , EmployeeDTO>, IEmployeeAppService
    {
        public EmployeeAppService(IRepository<Employee, int> repository) : base(repository)
        {
        }

        public IEnumerable<EmployeeDTO> SearchByName(string keyword)
        {
            var y = Repository.GetAll().Where(x => x.Name == keyword).Select(x => new EmployeeDTO {
                Dno = x.Dno,
                Name = x.Name,
                Id = x.Id,
                Salary = x.Salary })
                .ToList();
            return y;
        }

        public IEnumerable<Employee> SearchingByName(string keyword)
        {
            var list = Repository.GetAll().Where(x => x.Name == keyword).Include(x=>x.department.Departname);
            return list;
        }


        /*protected EmployeeAppService (IRepository<Employee, int> repository)
        {
            Repository = repository;
        }*/
        //protected override IQueryable<Employee> CreateFilteredQuery(EmployeeDTO input)
        //{
        //    var resutl = Repository.GetAll().Include("Departments");
        //    return Repository.GetAll();
        //}

        protected override IQueryable<Employee> CreateFilteredQuery(EmployeeDTO input)
        {
            var result = base.CreateFilteredQuery(input)
                .Include("department");
            return base.CreateFilteredQuery(input)
                .Include("department");

            
        }


    }


}
