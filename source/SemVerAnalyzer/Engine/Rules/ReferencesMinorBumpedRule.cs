using Pushpay.SemVerAnalyzer.Abstractions;
using Pushpay.SemVerAnalyzer.Assembly;

namespace Pushpay.SemVerAnalyzer.Engine.Rules
{
	internal class ReferencesMinorBumpedRule : IVersionAnalysisRule<AssemblyReference>
	{
		public VersionBumpType Bump => VersionBumpType.Minor;

		public bool Applies(AssemblyReference online, AssemblyReference local)
		{
			if (online == null || local == null) return false;

			return online.Version.MinorVersion() < local.Version.MinorVersion();
		}

		public string GetMessage(AssemblyReference info)
		{
			return $"The updated reference to {info.Name}@{info.Version} represents a minor bump.";
		}
	}
}
