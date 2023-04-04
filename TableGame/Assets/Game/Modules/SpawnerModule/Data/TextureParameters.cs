using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TableGame.Modules.SpawnerModule.Data
{
    [CreateAssetMenu(fileName = "Texture Values", menuName = "Spawner/New Texture Set", order = 0)]
    public class TextureParameters : ScriptableObject
    {
        [SerializeField] private UniqueTexture[] texturesData;

        private Queue<UniqueTexture> texturesNameQueue;

        private void OnEnable()
        {
            texturesNameQueue = new Queue<UniqueTexture>(texturesData.Distinct());
        }

        public async void DoLoadTexture(Action<Texture2D> __callback)
        {
            if (texturesNameQueue.Count < 0)
            {
                throw new ArgumentOutOfRangeException("no available textures");
            }

            Texture2D loadedTexture = await texturesNameQueue.Dequeue().LoadTexture();
            __callback?.Invoke(loadedTexture);
        }
    }
}