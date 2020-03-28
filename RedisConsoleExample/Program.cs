using System;

namespace RedisConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionManager manager = new DependencyInjectionManager();
            RedisController controller = new RedisController(manager);
            controller.Menu();

        }




    }
}
