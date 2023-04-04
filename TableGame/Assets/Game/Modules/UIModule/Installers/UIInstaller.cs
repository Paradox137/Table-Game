using TableGame.Modules.UIModule.Core;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace TableGame.Modules.UIModule
{
	public class UIInstaller : MonoInstaller
	{
		public const string RotateButtonId = "RotateButton";
		public const string FlipButtonId = "FlipButton";

		[SerializeField] private ButtonElement rotateButton;
		[SerializeField] private ButtonElement flipButton;

		public override void InstallBindings()
		{
			Container.BindInstance(rotateButton).WithId(RotateButtonId)
				.AsCached().NonLazy();
			Container.BindInstance(flipButton).WithId(FlipButtonId)
				.AsCached().NonLazy();
		}
	}
}
