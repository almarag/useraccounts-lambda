namespace Ama.UserAccountsLambda.Application
{
    using System.Reflection;

    public class AssemblyApplication
    {
        public Assembly GetAssembly()
        {
            return typeof(AssemblyApplication).GetTypeInfo().Assembly;
        }
    }
}
