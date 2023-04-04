using System.ComponentModel;
using TableGame.Modules.ItemModule.Core;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.ItemModule.Installers
{
	public class ItemObjectInstaller : MonoInstaller
	{
		[SerializeField] private ItemObject itemObject;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<ItemObject>().FromInstance(itemObject)
				.AsSingle().NonLazy();
		}
	}
}
