using System.Collections.Generic;

namespace SimpleProviderContainer
{
    /// <summary>
    /// Allows you to retrieve stored providers from a provider container.
    /// </summary>
    public class ProviderResolver<Tobj, Targ>
        where Tobj : IProvider<Targ>
    {

        private readonly ProviderContainer<Tobj, Targ> container;

        public ProviderResolver(ProviderContainer<Tobj, Targ> container)
        {
            this.container = container;
        }

        /// <summary>
        /// Get providers from the container's list of stored providers.
        /// </summary>
        public IEnumerable<Tobj> GetProvider(Targ arg)
        {
            return container.GetProviders(arg);
        }
    }
}
