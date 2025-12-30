using System.Reflection;

namespace Miami.App;

public partial class App
{
    private readonly Assembly _appAssembly = typeof(App).Assembly;

    private readonly Assembly[] _additionalAssemblies = new Assembly[]
    {
        typeof(Miami.Pages.One.PageOne).Assembly,
        typeof(Miami.Pages.Two.PageTwo).Assembly,
        typeof(Miami.Pages.Three.PageThree).Assembly,
        typeof(Miami.Pages.Chatbot.Chatbot).Assembly,
    };

}
