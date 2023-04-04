using TableGame.Modules.ItemModule.Core;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.Core
{
	public abstract class SignalView: IInitializable
	{
		protected readonly SignalBus SignalBus;
        
		protected readonly int InstanceId;
        
		public SignalView(IIdentifier __identifier, SignalBus __signalBus)
		{
			InstanceId = __identifier.InstanceId;
			SignalBus = __signalBus;
            
			SetupSignals();
		}

		public void Initialize() => SetupObserves();
        

		protected abstract void SetupSignals();
		protected abstract void SetupObserves();
	}
}
