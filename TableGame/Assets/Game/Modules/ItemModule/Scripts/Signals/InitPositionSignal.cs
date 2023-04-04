using UnityEngine;

namespace TableGame.Modules.ItemModule.Signals
{
	public struct InitPositionSignal
	{
		public readonly int Id;

		public readonly Transform Parent;
        
		public readonly Vector3 Position;

		public InitPositionSignal(int __id, Transform __par, Vector3 __pos)
		{
			Id = __id;
			Parent = __par;
			Position = __pos;
		}
	}
}
