using WinForms_DI.Forms;

namespace WinForms_DI.Factory
{
    public class FormFactory : IFormFactory
    {
        static IFormFactory _provider;

        public static void SetProvider(IFormFactory provider)
        {
            _provider = provider;
        }
        public Main CreateMain() => _provider.CreateMain();

    }
}
