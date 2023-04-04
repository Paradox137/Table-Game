using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.ItemModule.MVC.View.RotateView;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.Installers.Rotate_Installers
{
	public abstract class RotateViewInstaller<T> : MonoInstaller
		where T : RotateView
	{
		[SerializeField] private ItemTransformData data;
		[SerializeField] private Transform rotateTransform;
		[Space(15)] [SerializeField] private Vector3 direction;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<T>().
				FromSubContainerResolveAll().
				ByMethod(InstallFacade).
				AsSingle().
				NonLazy();
		}

		void InstallFacade(DiContainer __subContainer)
		{
			RotateModel rm = new RotateModel();
			
			__subContainer.Bind<Transform>().
				FromInstance(rotateTransform).
				AsSingle();
			__subContainer.Bind<RotateModel>().
				To<RotateModel>().
				FromInstance(rm).
				AsSingle();
			__subContainer.Bind<RotatePresenter>().
				FromInstance(new RotatePresenter(rm, data, direction)).
				AsSingle();

			__subContainer.BindInterfacesAndSelfTo<T>().
				AsSingle().
				NonLazy();
		}
	}
}
