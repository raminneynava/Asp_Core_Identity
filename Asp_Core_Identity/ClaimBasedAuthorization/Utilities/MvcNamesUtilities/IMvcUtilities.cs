using System.Collections.Immutable;

namespace Asp_Core_Identity
{
    public interface IMvcUtilities
    {
        public ImmutableHashSet<MvcNamesModel> MvcInfo { get; }

        public ImmutableHashSet<MvcNamesModel> MvcInfoForActionsThatRequireClaimBasedAuthorization { get; }
    }
}
