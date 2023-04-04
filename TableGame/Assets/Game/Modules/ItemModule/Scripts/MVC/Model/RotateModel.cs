using UniRx;

namespace TableGame.Modules.ItemModule.MVC.Model
{
	public class RotateModel
	{
		public ReactiveProperty<float> NextAngle { get; set; }

		public RotateModel()
		{
			NextAngle = new ReactiveProperty<float>(0f);
		}
	}
}
