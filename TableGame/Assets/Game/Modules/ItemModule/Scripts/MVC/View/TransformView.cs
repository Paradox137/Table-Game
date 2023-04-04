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
	
	public class TransformView : SignalView
	{
		private readonly Rigidbody rb;
		private readonly Transform transform;

		private readonly TransformPresenter presenter;
		private readonly TransformModel model;

		private Tween currentTween;

		public TransformView(Rigidbody __rb,
			TransformPresenter __presenter, TransformModel __model,
			IIdentifier __item, SignalBus __bus) : base(__item, __bus)
		{
			this.model = __model;
			this.presenter = __presenter;

			this.rb = __rb;
			transform = this.rb.transform;
		}

		protected override void SetupSignals()
		{
			SignalBus.Subscribe<InitPositionSignal>(__p =>
			{
				if (__p.Id != InstanceId) return;
				transform.SetParent(__p.Parent);
				presenter.OnTransformInstance(__p.Position);
			});
			SignalBus.Subscribe<SelectSignal>(__s =>
			{
				if (__s.SelectedId == InstanceId)
				{
					presenter.OnSelect();

					rb.transform.rotation = Quaternion.identity;
					rb.isKinematic = true;
				}
				else
				{
					rb.isKinematic = false;
					presenter.OnDeselect();
				}
			});
			SignalBus.Subscribe<MoveSignal>(__m =>
			{
				if (__m.Id == InstanceId)
					presenter.OnMove(__m.MoveDirection);
			});
		}
		protected override void SetupObserves()
		{
			SetupInitPositionObserve();
			SetupSelectObserve();
			SetupRigidbodyMoveObserve();
		}

		#region Observes
		private void SetupInitPositionObserve() =>
			model.Position.ObserveEveryValueChanged(__pos => __pos.Value).
				Subscribe(__pos => transform.position = __pos).
				AddTo(transform);

		private void SetupRigidbodyMoveObserve() =>
			model.Direction.ObserveEveryValueChanged(__pos => __pos.Value).
				Subscribe(__dir => rb.MovePosition(transform.position + __dir)).
				AddTo(transform);

		private void SetupSelectObserve() =>
			model.Selection.ObserveEveryValueChanged(__s => __s.Value).
				Subscribe(__t =>
				{
					currentTween?.Kill();

					currentTween = __t switch
					{
						SelectionType.Select => presenter.SelectAnimation(transform),
						_ => currentTween
					};

					currentTween.Play();
				}).
				AddTo(transform);
		#endregion
	}
}
