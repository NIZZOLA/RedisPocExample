using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisConsoleExample
{
    public interface IDependencyInjectionManager
    {
        ServiceProvider ServiceProvider { get; }
    }

}
