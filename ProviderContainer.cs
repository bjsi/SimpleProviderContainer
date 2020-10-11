using System.Collections.Generic;

namespace SimpleProviderContainer
{
    /// <summary>
    /// Stores a collection of providers of the same type that can provide services depending on the result of some predicate.
    /// </summary>
    public class ProviderContainer<Tobj, Targ>
        where Tobj : IProvider<Targ>
    {

        private List<Tobj> _providers = new List<Tobj>();

        /// <summary>
        /// Add a provider to the list of providers
        /// </summary>
        public void AddProvider(Tobj provider)
        {
            _providers.Add(provider);
        }

        /// <summary>
        /// Get providers based on the return value of their CanHandle method.
        /// </summary>
        public IEnumerable<Tobj> GetProviders(Targ arg)
        {
            return _providers.Where(p => p.CanHandle(arg));
        }
    }
}
