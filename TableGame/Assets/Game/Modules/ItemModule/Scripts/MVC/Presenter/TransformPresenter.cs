using System;
using DG.Tweening;
using TableGame.Modules.ItemModule.Data;
using TableGame.Modules.ItemModule.MVC.Core;
using TableGame.Modules.ItemModule.MVC.Model;
using UnityEngine;

namespace TableGame.Modules.ItemModule.MVC.Presenter
{
	public class TransformPresenter
	{
		private readonly TransformModel model;
		private readonly ItemTransformData data;

		public Func<Transform, Tween> SelectAnimation;
		public Func<Transform, Tween> UnselectAnimation;

		public TransformPresenter(TransformModel __model, ItemTransformData __data)
		{
			this.model = __model;
			this.data = __data;
		}

		public void OnTransformInstance(Vector3 __instancePosition)
		{
			float startHeight = __instancePosition.y;
			float endHeight = startHeight + data.JumpHeight;

			SelectAnimation = __transform =>
				__transform.DOMoveY(endHeight, data.JumpDuration);
			UnselectAnimation = __transform =>
				__transform.DOMoveY(startHeight, data.JumpDuration);

			model.Position.Value = __instancePosition;
		}
        

		public void OnSelect() => model.Selection.Value = SelectionType.Select;
		public void OnDeselect() => model.Selection.Value = SelectionType.Unselect;
        
		public void OnMove(Vector2 __direction)
		{
			var endDir = new Vector3(__direction.x, 0f, __direction.y) 
				* data.MoveSpeed * Time.deltaTime;
			model.Direction.Value = endDir;
		}

		private void UpdateHeight(float __curHeight)
		{
			var cur = model.Position.Value;
			cur.y = __curHeight;

			model.Position.Value = cur;
		}
	}
}
