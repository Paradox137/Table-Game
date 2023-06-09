﻿using TableGame.Modules.ItemModule.MVC.Core;
using UniRx;
using UnityEngine;

namespace TableGame.Modules.ItemModule.MVC.Model
{
	public class TransformModel
	{
		public ReactiveProperty<Vector3> Position { get; set; }
		public ReactiveProperty<Vector3> Direction { get; private set; }
		public ReactiveProperty<SelectionType> Selection { get; set; }

		public TransformModel()
		{
			Position = new ReactiveProperty<Vector3>(Vector3.zero);
			Direction= new ReactiveProperty<Vector3>(Vector3.zero);
			
			Selection = new ReactiveProperty<SelectionType>(SelectionType.None);
		}
	}
}
