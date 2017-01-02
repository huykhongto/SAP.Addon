using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAP.AddOn.App_Start
{
    public static class ModelMapper
    {
        public static void RegisterAutoMapperMap()
        {
            AutoMapper.Mapper.CreateMap<ZOOAT, ZOOATViewModel>();
            AutoMapper.Mapper.CreateMap<ZOOATViewModel, ZOOAT>();
        }
    }
}