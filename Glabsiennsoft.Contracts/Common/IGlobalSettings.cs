using System.Reflection;

namespace Glabsiennsoft.Contracts.Common
{
    public interface IGlobalSettings
    {
        string MigrationAssemblyName { get; }
        string DefaultConnectionString { get; }
    }
}