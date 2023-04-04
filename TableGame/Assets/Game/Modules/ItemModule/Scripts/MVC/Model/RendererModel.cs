using UniRx;
using UnityEngine;

namespace TableGame.Modules.ItemModule.MVC.Model
{
	public class RendererModel
	{
		public ReactiveProperty<Color> Color { get; set; }

		public ReactiveProperty<Texture2D> Texture { get; set; }


		public RendererModel()
		{
			Color = new ColorReactiveProperty(UnityEngine.Color.white);
			Texture = new ReactiveProperty<Texture2D>(Texture2D.whiteTexture);
		}
	}
}
