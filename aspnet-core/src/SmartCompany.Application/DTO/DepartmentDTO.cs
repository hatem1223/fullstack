using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartCompany.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCompany.DTO
{
    [AutoMap(typeof(Department))]
    public class DepartmentDTO:EntityDto
    {
        public string Departname { get; set; }
    }
}
