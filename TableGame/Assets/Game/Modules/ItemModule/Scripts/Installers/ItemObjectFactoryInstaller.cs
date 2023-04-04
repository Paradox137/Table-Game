using TableGame.Modules.ItemModule.Core;
using Zenject;

namespace TableGame.Modules.ItemModule.Installers
{
	public class ItemObjectFactoryInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindFactory<UnityEngine.Object, ItemObject, ItemObject.Factory>()
				.FromFactory<PrefabFactory<ItemObject>>();
		}
	}
}
