using TableGame.Modules.InputModule.Signals;
using TableGame.Modules.ItemModule.Signals;
using TableGame.Modules.UIModule;
using Zenject;

namespace TableGame.Modules.CoreModule
{
	public class SignalsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);

			Container.DeclareSignal<InitPositionSignal>();
			Container.DeclareSignal<InputPositionSignal>();

			Container.DeclareSignal<InitTextureSignal>();

			Container.DeclareSignal<SelectSignal>();
			Container.DeclareSignal<MoveSignal>();

			Container.DeclareSignal<BoolSignal>();
		}
	}
}
