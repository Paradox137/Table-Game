using UnityEngine;

namespace TableGame.Modules.InputModule.Signals
{
	public struct MoveSignal
	{
		public readonly int Id;
		public readonly Vector2 MoveDirection;

		public MoveSignal(int __id, Vector2 __moveDirection)
		{
			Id = __id;
			MoveDirection = __moveDirection;
		}
	}
}
