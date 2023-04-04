using UnityEngine;

namespace TableGame.Modules.ItemModule.Data
{
	[CreateAssetMenu(fileName = "Item Transform Data", menuName = "Item Data/Transform Data", order = 0)]
	public class ItemTransformData : ScriptableObject
	{
		[field: SerializeField] public float MoveSpeed { get; private set; }
		[field: SerializeField] public float RotateSpeed { get; private set; }
		
		[field: Space(15)]
		
		[field: SerializeField] public float JumpHeight { get; private set; }
		[field: SerializeField] public float JumpDuration { get; private set; }
	}
}
