using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.Core
{
	[RequireComponent(typeof(Rigidbody))] public class ItemObject : MonoBehaviour, IIdentifier
	{
		public int InstanceId
		{
			get
			{
				return gameObject.GetInstanceID();
			}
		}

		public class Factory : PlaceholderFactory<UnityEngine.Object, ItemObject>
		{
		}
	}
}
