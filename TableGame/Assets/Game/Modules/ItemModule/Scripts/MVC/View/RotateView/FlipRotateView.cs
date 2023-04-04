using TableGame.Modules.ItemModule.Core;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.UIModule;
using TableGame.Modules.UIModule.Core;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.View.RotateView
{
	public class FlipRotateView : RotateView
	{
		private const float FlipRotateAngle = 180.01f;

		protected sealed override ButtonElement ButtonElement { get; set; }

		public FlipRotateView(Transform __transform, RotateModel __model, RotatePresenter __presenter,
			[Inject(Id = UIInstaller.FlipButtonId)] ButtonElement __buttonElement,
			IIdentifier __identifier, SignalBus __signalBus)
			: base(__transform, FlipRotateAngle, __model, __presenter, __identifier, __signalBus)
		{
			ButtonElement = __buttonElement;
		}
	}
}
