using DG.Tweening;
using TableGame.Modules.InputModule.Signals;
using TableGame.Modules.ItemModule.Core;
using TableGame.Modules.ItemModule.MVC.Core;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.ItemModule.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.View
{
	public class RendererView : SignalView
	{
		private readonly Renderer renderer;

		private readonly RendererPresenter presenter;
		private readonly RendererModel model;

		private Tween tween;

		public RendererView(Renderer __renderer, RendererPresenter __presenter,
			RendererModel __model, IIdentifier __identifier, SignalBus __signalBus) : base(__identifier, __signalBus)
		{
			presenter = __presenter;
			model = __model;
			renderer = __renderer;
		}
		protected override void SetupSignals()
		{
			SignalBus.Subscribe<InitTextureSignal>(__t =>
			{
				if (__t.Id != InstanceId) return;
				presenter.OnSetupTexture(__t.Texture);
			});
			SignalBus.Subscribe<SelectSignal>(__s =>
			{
				if (__s.SelectedId == InstanceId) presenter.OnSelect();
				else presenter.OnDeselect();
			});
		}
		protected override void SetupObserves()
		{
			SetupTextureObserve();
			SetupColorObserve();
		}

		private void SetupTextureObserve()
		{
			model.Texture.ObserveEveryValueChanged(__t => __t.Value).
				Subscribe(__texture => renderer.material.mainTexture = __texture).
				AddTo(renderer);
		}

		private void SetupColorObserve()
		{
			model.Color.ObserveEveryValueChanged(__c => __c.Value).
				Subscribe(__color =>
				{
					tween?.Kill();
					tween = renderer.material.DOColor(__color, presenter.AnimateColorDuration);
					tween.Play();
				}).
				AddTo(renderer);
		}
	}
}
