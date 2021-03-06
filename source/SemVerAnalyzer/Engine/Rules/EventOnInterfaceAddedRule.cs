using dnlib.DotNet;
using Pushpay.SemVerAnalyzer.Abstractions;

namespace Pushpay.SemVerAnalyzer.Engine.Rules
{
	internal class EventOnInterfaceAddedRule : IVersionAnalysisRule<EventDef>
	{
		public VersionBumpType Bump => VersionBumpType.Major;

		public bool Applies(EventDef online, EventDef local)
		{
			var type = (online ?? local).DeclaringType;

			return type.IsInterface && online == null && local != null;
		}

		public string GetMessage(EventDef info)
		{
			return $"`{info.GetName()}` is new or has been made accessible.";
		}
	}
}
