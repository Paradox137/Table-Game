using TableGame.Modules.InputModule.Core;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.InputModule.Installers
{
	public class InputServiceInstaller : MonoInstaller
	{
		[SerializeField] private Camera camera;

		public override void InstallBindings()
		{
			Container.BindInstance(camera).AsSingle();
			Container.Bind<PlayerInput>().AsSingle();
			Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
		}
	}
}
