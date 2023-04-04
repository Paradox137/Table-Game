using TableGame.Modules.SpawnerModule.Data;
using UnityEngine;
using Zenject;

namespace TableGame.Modules.SpawnerModule.Installers
{
    public sealed class SpawnerInstaller: MonoInstaller
    {
        [SerializeField] private SpawnerParameters spawnerParameters;

        public override void InstallBindings()
        {
            
        }
    }
}