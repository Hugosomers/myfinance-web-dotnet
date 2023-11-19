using System.Reflection;

namespace myfinance_web_dotnet.Infrastructures
{
  public class AssemblyUtil
  {
    public static IEnumerable<Assembly> GetCurrentAssemblies()
    {
      return new Assembly[] {
        Assembly.Load("myfinance-web-dotnet")
    };
    }
  }
}