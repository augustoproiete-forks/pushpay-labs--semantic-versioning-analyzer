namespace Pushpay.SemVerAnalyzer.Abstractions
{
	public enum VersionBumpType
	{
		Unknown,
		Downgrade,
		None,
		Patch,
		Minor,
		Major
	}
}
