using System;
using System.Linq;
using AutoMapper;
using NexusCore.Infrasructure.Adapter.Mapping;

namespace NexusCore.Common.Adapter.Mapping
{
    public class AutoMapperAdapterFacotry : IMapperAdapterFactory
    {

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutoMapperAdapterFacotry()
        {
            //scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            });

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }

        public IMapperAdapter Create()
        {
            return new AutoMapperAdapter();
        }
    }
}
