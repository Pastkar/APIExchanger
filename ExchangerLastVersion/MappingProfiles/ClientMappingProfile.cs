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
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientBl, ClientModel>();
            CreateMap<ClientCreateModel, ClientCreateBl>();

            CreateMap<Client, ClientBl>();
            CreateMap<ClientCreateBl, Client>();

        }
    }
}
