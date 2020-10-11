using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProviderContainer
{
    public interface IProvider<T>
    {
        bool CanHandle(T arg);
    }
}
