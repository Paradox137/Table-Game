using TableGame.Modules.ItemModule.Core;
using TableGame.Modules.ItemModule.MVC.Core;
using TableGame.Modules.ItemModule.MVC.Model;
using TableGame.Modules.ItemModule.MVC.Presenter;
using TableGame.Modules.UIModule;
using TableGame.Modules.UIModule.Core;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.MVC.View.RotateView
{
	public class LineRotateView : RotateView
	{
		private const float LineRotateAngle = 90f;

		protected sealed override ButtonElement ButtonElement { get; set; }

		public LineRotateView
		(Transform __transform, RotateModel __model, RotatePresenter __presenter,
			[Inject(Id = UIInstaller.RotateButtonId)] ButtonElement __buttonElement,
			IIdentifier __identifier, SignalBus __signalBus)
			: base(__transform, LineRotateAngle, __model, __presenter, __identifier, __signalBus)
		{
			ButtonElement = __buttonElement;
		}
	}
}
