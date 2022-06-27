using WinForms_DI.Services;

namespace WinForms_DI.Forms
{
    public partial class Main : Form
    {

        private readonly IHelloWorldService helloService;

        public Main(IHelloWorldService helloService)
        {
            InitializeComponent();
            this.helloService = helloService;
            MessageBox.Show(helloService.DoWork());
        }
    }
}
