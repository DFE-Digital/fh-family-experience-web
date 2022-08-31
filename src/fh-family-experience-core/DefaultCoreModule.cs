namespace fh_family_experience_core;

using Autofac;
using fh_family_experience_core.Interfaces;
using fh_family_experience_core.Services;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SearchService>().As<ISearchService>().InstancePerLifetimeScope();
    }
}
