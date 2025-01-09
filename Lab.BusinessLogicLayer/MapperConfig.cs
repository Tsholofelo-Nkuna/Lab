using AutoMapper;
using Lab.BusinessLogicLayer.Models.DataTransferObjects;
using Lab.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.BusinessLogicLayer
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            this.CreateMap<TestDto, TestEntity>().ReverseMap();
            this.CreateMap<RequisitionDto, RequisitionEntity>().ReverseMap();
            this.CreateMap<TestResultDto, TestResultEntity>().ReverseMap();
        }
    }
}
