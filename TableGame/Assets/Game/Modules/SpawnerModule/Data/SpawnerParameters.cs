using System.Collections.Generic;
using TableGame.Modules.ItemModule.Core;
using UnityEngine;

namespace TableGame.Modules.SpawnerModule.Data
{
    [CreateAssetMenu(fileName = "Spawner Data", menuName = "Spawner/New Spawner Values", order = 0)]
    public sealed class SpawnerParameters : ScriptableObject
    {
        [SerializeField] private int totalInstanceCount;
        
        [SerializeField] private ItemObject[] itemViewsPrefabs;
        
        [SerializeField] private GridParameters gridParameters;

        private HashSet<ItemObject> items;

        public HashSet<ItemObject> ItemPrefabs 
        {
            get
            {
                items ??= new HashSet<ItemObject>(itemViewsPrefabs);
                return items;
            }
        }

        public GridParameters GridValue => gridParameters;
        
        public int CountPerPrefab => TotalCount/ItemPrefabs.Count;
        public int TotalCount => totalInstanceCount;
    }
}