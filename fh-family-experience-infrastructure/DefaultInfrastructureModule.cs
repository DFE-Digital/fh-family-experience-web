namespace fh_family_experience_infrastructure;

using Autofac;
using fh_family_experience_infrastructure.Data;
using fh_family_experience_sharedkernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Module = Autofac.Module;

public class DefaultInfrastructureModule : Module
{
    private readonly bool _isDevelopment = false;

    public DefaultInfrastructureModule(bool isDevelopment)
    {
        _isDevelopment = isDevelopment;
    }

    protected override void Load(ContainerBuilder builder)
    {
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }

        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IReadRepository<>)).InstancePerLifetimeScope();
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
        //builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only services here
        //builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
        //  .InstancePerLifetimeScope();
    }
}
