using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Model;
using UnityEngine;

namespace TableGame.Modules.ItemModule.MVC.Presenter
{
	public class RendererPresenter
	{
		private readonly RendererModel model;
		private readonly ItemRendererData data;

		public float AnimateColorDuration => data.SetColorDuration;
        
		public RendererPresenter(RendererModel __model, ItemRendererData __data)
		{
			this.model = __model;
			this.data = __data;
		}

		public void OnSetupTexture(Texture2D __texture) => model.Texture.Value = __texture;

		public void OnSelect() => model.Color.Value = data.SelectColor;
		public void OnDeselect() => model.Color.Value = data.UnselectColor;
	}
}
