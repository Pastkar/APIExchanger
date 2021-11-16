using AutoMapper;
using BusinessLogic.Entities;
using DataAccessLayer.Entities;
using ExchangerLastVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangerLastVersion.MappingProfiles
{
    public class OperatorMappingProfile : Profile 
    {
        public OperatorMappingProfile()
        {
            CreateMap<OperatorBl, OperatorModel>();
            CreateMap<OperatorCreateModel, OperatorCreateBl>();

            CreateMap<Operator, OperatorBl>();
            CreateMap<OperatorCreateBl, Operator>();
        }
    }
}
