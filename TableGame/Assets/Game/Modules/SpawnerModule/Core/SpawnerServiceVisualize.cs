#if UNITY_EDITOR
using TableGame.Modules.SpawnerModule.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace TableGame.Modules.SpawnerModule.Core
    {
        public class SpawnerServiceVisualize : MonoBehaviour
        {
            [SerializeField] private SpawnerParameters spawnerParameters;
            [Space(15)] 
            [SerializeField] private Transform spawnerTransform;
            
            private void OnDrawGizmos()
            {
                var xSize = spawnerParameters.GridValue.CellSize.x;
                var zSize = spawnerParameters.GridValue.CellSize.y;
                
                var xCount = spawnerParameters.GridValue.WidthCellCount;
                var zCount = spawnerParameters.GridValue.HeightCellCount;

                Gizmos.color = new Color(1, 0, 0, 0.5f);

                var spawnerPosition =
                    spawnerTransform.position;
                
                for (int i = 0; i < xCount; i++)
                {
                    for (int j = 0; j < zCount; j++)
                    {
                        var curPos = spawnerPosition + new Vector3(xSize * i, 0f, - zSize* j);
                        
                        Gizmos.DrawCube(curPos+Vector3.up*0.1f,new Vector3(xSize*0.95f,0.1f,zSize*0.95f));
                    }
                }
            }
        }
    }
#endif