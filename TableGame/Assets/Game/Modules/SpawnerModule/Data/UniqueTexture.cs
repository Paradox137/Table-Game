using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

namespace TableGame.Modules.SpawnerModule.Data
{
    [CreateAssetMenu(fileName = "Texture Data", menuName = "Spawner/New Texture Data", order = 0)]
    public class UniqueTexture: ScriptableObject
    {
        [SerializeField] private string textureName;
        [Space(10)] 
        [SerializeField] private bool isLoadFromWWW;
        
        public async UniTask<Texture2D> LoadTexture()
        {
            return !isLoadFromWWW
                ? await DownloadFromLocal($"{Application.dataPath}/AssetPacks/StreamingAssets/Sprites/{textureName}.png")
                : await DownloadFromWWW(textureName);
        }

        private static async UniTask<Texture2D> DownloadFromLocal(string __path)
        {
            var file = new FileInfo(__path);
            byte[] bytes;
            
            if (file.Exists)
            {
                bytes = await File.ReadAllBytesAsync(__path);

                var texture = new Texture2D(1, 1);
                texture.LoadImage(bytes);
                
                return texture;
            }
            throw new NullReferenceException("Cant find path " + __path);
        }
        private static async UniTask<Texture2D> DownloadFromWWW(string __path)
        {
            using var request = UnityWebRequestTexture.GetTexture(__path);
            
            await request.SendWebRequest();
            
            return  request.result == UnityWebRequest.Result.Success
                ? DownloadHandlerTexture.GetContent(request) : null;
        }
    }
}