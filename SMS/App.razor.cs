using System.Reflection;

namespace SMS
{
    public partial class App
    {
        private readonly List<Assembly> _lazyLoadedAssemblies = [];

        protected override void OnInitialized()
        {
            _lazyLoadedAssemblies.Add(typeof(App).Assembly);
        }

    }
}