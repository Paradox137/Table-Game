using TableGame.Modules.InputModule.Core;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TableGame.Modules.InputModule.Installers
{
	public class InputServiceInstaller : MonoInstaller
	{
		[SerializeField] private Camera _camera;

		public override void InstallBindings()
		{
			Container.BindInstance(_camera).AsSingle();
			Container.Bind<PlayerInput>().AsSingle();
			Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
		}
	}
}
