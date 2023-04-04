using System.Collections.Generic;
using TableGame.Modules.ItemModule.Core;
using TableGame.Modules.ItemModule.Signals;
using TableGame.Modules.SpawnerModule.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TableGame.Modules.SpawnerModule.Core
{
    public struct Grid
    {
        public readonly Queue<Vector3> GenerateCells;

        private Vector3[] gridCells;
        
        public Grid(Vector3 __leftCorner,GridParameters __gridParameters,int __needCellCount)
        {
            GenerateCells = new Queue<Vector3>();
            
            var xSize = __gridParameters.CellSize.x;
            var zSize = __gridParameters.CellSize.y;
                
            var xCount = __gridParameters.WidthCellCount;
            var zCount = __gridParameters.HeightCellCount;
            
           gridCells = new Vector3[xCount * zCount];

            float fault = __gridParameters.FaultValue;
            int count = 0;
            
            for (var i = 0; i < xCount; i++)
            {
                for (var j = 0; j < zCount; j++)
                {
                    Vector3 rnd = new Vector3(Random.value, 0f, Random.value) * fault;
                    var curPos =
                        __leftCorner + 
                        new Vector3(xSize * i, 0f, - zSize* j) + rnd;
                    
                    gridCells[count] = curPos;
                    
                    count++;
                }
            }
            
            GenerateAvailableCells(__needCellCount);
        }

        private void GenerateAvailableCells(int __needCellCount)
        {
            int arrCount = gridCells.Length;

            while (GenerateCells.Count < __needCellCount)
            {
                var rnd = Random.Range(0, arrCount);
                var selected = gridCells[rnd];
                
                if(!GenerateCells.Contains(selected))
                    GenerateCells.Enqueue(selected);
            }
        }
    }
    
    public class SpawnerService: MonoBehaviour
    {
        [SerializeField] private Transform spawnerLeftCorner;
        [SerializeField] private SpawnerParameters spawnerData;
        [SerializeField] private TextureParameters textureParameters;

        private Grid grid;

        [Inject]
        private void Constructor(ItemObject.Factory __factory, SignalBus __bus)
        {
            grid = new Grid(spawnerLeftCorner.position, 
                spawnerData.GridValue, spawnerData.TotalCount);
            
            InstantiateViews(__factory,__bus);
        }

        private void InstantiateViews(ItemObject.Factory __factory, SignalBus __bus)
        {
            Transform parent = new GameObject("Items Container").transform;
            
            int cellPerInstance = spawnerData.CountPerPrefab;
            
            foreach (var prefab in spawnerData.ItemPrefabs)
            {
                for (var j = 0; j < cellPerInstance; j++)
                {
                    Vector3 selectedCell = grid.GenerateCells.Dequeue();
                    
                    var instance = __factory.Create(prefab);

                    __bus.TryFire(new InitPositionSignal(
                        instance.InstanceId,parent,selectedCell));
                    
                    textureParameters.DoLoadTexture(__t => 
                        __bus.TryFire(new InitTextureSignal(instance.InstanceId, __t)));
                }
            }
        }
    }
}