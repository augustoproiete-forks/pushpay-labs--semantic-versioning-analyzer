using dnlib.DotNet;
using Pushpay.SemVerAnalyzer.Abstractions;

namespace Pushpay.SemVerAnalyzer.Engine.Rules
{
	internal class InaccessiblePropertySetterIsNowProtectedRule : IVersionAnalysisRule<PropertyDef>
	{
		public VersionBumpType Bump => VersionBumpType.Minor;

		public bool Applies(PropertyDef online, PropertyDef local)
		{
			if (online == null || local == null) {
				return false;
			}

			return online.SetMethod != null && !(online.SetMethod.IsFamily || online.SetMethod.IsPublic) &&
				   local.SetMethod != null && local.SetMethod.IsFamily;
		}

		public string GetMessage(PropertyDef info)
		{
			return $"`{info.GetName()}` setter was inaccessible and is now protected.";
		}
	}
}
