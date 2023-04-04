using TableGame.Modules.ItemModule.Core;

namespace TableGame.Modules.InputModule.Signals
{
	public struct SelectSignal
	{
		public readonly int? SelectedId;

		public SelectSignal(IIdentifier __identifier)
		{
			SelectedId = __identifier?.InstanceId ?? null;
		}
	}
}
