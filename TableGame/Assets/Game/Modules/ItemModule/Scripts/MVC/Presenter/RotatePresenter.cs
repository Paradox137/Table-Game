using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Model;
using UnityEngine;

namespace TableGame.Modules.ItemModule.MVC.Presenter
{
	public class RotatePresenter
	{
		private readonly RotateModel model;
		private readonly ItemTransformData data;

		public readonly Vector3 Direction;
        
		public float RotateDuration => 1 / data.RotateSpeed;

		public RotatePresenter(RotateModel __model,ItemTransformData __data, Vector3 __direction)
		{
			this.model = __model;
			this.data = __data;

			Direction = __direction.normalized;
		}

		public void DoRotate(float __baseAngle) => model.NextAngle.Value += __baseAngle;
	}
}
