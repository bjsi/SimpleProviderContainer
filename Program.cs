using System;
using System.Linq;

namespace SimpleProviderContainer
{
    class Program
    {

        public interface INameProvider : IProvider<int>
        {
            void Print();
        }

        public class NameProvider : INameProvider
        {

            private readonly string _name;
            private readonly Func<int, bool> _canHandle;

            public NameProvider(string name, Func<int, bool> canHandle)
            {
                this._name = name;
                this._canHandle = canHandle;
            }

            public bool CanHandle(int x) => _canHandle(x);

            public void Print() => Console.WriteLine(_name);
        }

        static void Main(string[] args)
        {
            var prov1 = new NameProvider("james", x => x > 2);
            var prov2 = new NameProvider("naess", x => x > 3);

            var providerContainer = new ProviderContainer<INameProvider, int>();
            providerContainer.AddProvider(prov1);
            providerContainer.AddProvider(prov2);

            var providerResolver = new ProviderResolver<INameProvider, int>(providerContainer);
            var providers = providerResolver.GetProvider(3);
        }
    }
}
