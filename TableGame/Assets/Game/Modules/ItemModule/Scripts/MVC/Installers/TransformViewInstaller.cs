using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.ItemModule.MVC.View;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.Installers
{
	public sealed class TransformViewInstaller : MonoInstaller
	{
		[SerializeField] private Rigidbody rigidBody;
		[SerializeField] private ItemTransformData transformData;

		public override void InstallBindings()
		{
			Container.BindInstance(rigidBody).
				AsSingle();
			Container.BindInstance(transformData).
				AsSingle();

			Container.Bind<TransformModel>().
				AsSingle();
			Container.Bind<TransformPresenter>().
				AsSingle();

			Container.BindInterfacesAndSelfTo<TransformView>().
				AsSingle().
				NonLazy();
		}
	}
}
