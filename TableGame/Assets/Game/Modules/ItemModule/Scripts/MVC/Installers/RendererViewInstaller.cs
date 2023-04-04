using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.ItemModule.MVC.View;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.Installers
{
	public class RendererViewInstaller : MonoInstaller
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private ItemRendererData rendererData;

		public override void InstallBindings()
		{
			Container.BindInstance(_renderer).
				AsSingle().
				NonLazy();
			Container.BindInstance(rendererData).
				AsSingle();

			Container.Bind<RendererModel>().
				AsSingle();
			Container.Bind<RendererPresenter>().
				AsSingle();
			Container.BindInterfacesAndSelfTo<RendererView>().
				AsSingle().
				NonLazy();
		}
	}
}
