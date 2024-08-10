using Pi_junção;

namespace codsf0;

static class Program
{    
    static void Main()
    {        
        ApplicationConfiguration.Initialize();
        Application.Run(new PedidosV());
    }    
}