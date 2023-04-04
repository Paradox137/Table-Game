using DG.Tweening;
using TableGame.Modules.InputModule.Signals;
using TableGame.Modules.ItemModule.Core;
using TableGame.Modules.ItemModule.MVC.Core;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.UIModule;
using TableGame.Modules.UIModule.Core;
using UniRx;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.View.RotateView
{
	public abstract class RotateView : SignalView
	{
		private readonly Transform transform;

		private readonly RotateModel model;
		private readonly RotatePresenter presenter;

		private readonly float angle;

		private Tween rotateAnimation;

		protected abstract ButtonElement ButtonElement { get; set; }

		public RotateView(Transform __transform, float __angle,
			RotateModel __model, RotatePresenter __presenter,
			IIdentifier __identifier, SignalBus __signalBus)
			: base(__identifier, __signalBus)
		{
			this.transform = __transform;

			this.model = __model;
			this.presenter = __presenter;

			this.angle = __angle;
		}

		protected override void SetupSignals()
		{
			SignalBus.Subscribe<SelectSignal>(__s =>
				ButtonElement.SetActive(InstanceId, __s.SelectedId == InstanceId, OnClick));
		}
		protected override void SetupObserves()
		{
			SetupRotateObserve();
		}

		private void SetupRotateObserve() => model.NextAngle.ObserveEveryValueChanged(__a => __a.Value).
			Subscribe(__nextAngle =>
			{
				if (__nextAngle == 0)
					return;

				rotateAnimation?.Kill();
				var to = presenter.Direction * angle + transform.eulerAngles;

				rotateAnimation =
					transform.DORotateQuaternion(Quaternion.Euler(to), presenter.RotateDuration).
						OnComplete(() => SignalBus.TryFire(new BoolSignal(true)));

			}).
			AddTo(transform);


		private void OnClick()
		{
			SignalBus.TryFire(new BoolSignal(false));
			presenter.DoRotate(angle);
		}
	}
}
