namespace WinForms_DI.Services
{
    public class HelloWorldServiceImpl : IHelloWorldService
    {
        public string DoWork()
        {
            return "hello world service::do work";
        }
    }
}
