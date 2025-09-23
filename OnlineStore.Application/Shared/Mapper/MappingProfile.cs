using AutoMapper;
using System.Reflection;

namespace OnlineStore.Application.Shared.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                ApplyMappingsFromAssembly(assembly);
            }
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            try
            {
                var types = assembly.GetExportedTypes()
                    .Where(t => t.GetInterfaces().Any(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                    .ToList();

                for (var i = 0; i < types.Count(); i++)
                {
                    if (types[i].Name != "MapFrom`1")
                    {
                        var instance = Activator.CreateInstance(types[i]);
                        var methodInfo = types[i].GetMethod("Mapping");
                        methodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
