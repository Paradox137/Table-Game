using UnityEngine;

namespace TableGame.Modules.ItemModule.Signals
{
	public struct InitTextureSignal
	{
		public readonly int Id;
		public readonly Texture2D Texture;

		public InitTextureSignal(int __id, Texture2D __texture)
		{
			Id = __id;
			Texture = __texture;
		}
	}
}
