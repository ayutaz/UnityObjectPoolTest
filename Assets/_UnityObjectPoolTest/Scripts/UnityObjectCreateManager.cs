using _UniRxObjectPoolTest;
using Common;
using UnityEngine;
using UnityEngine.Pool;

namespace _UnityObjectPoolTest
{
    public class UnityObjectCreateManager : MonoBehaviour
    {
        [SerializeField] private ImageEffect imageEffect;
        private ObjectPool<ImageEffect> _imageEffectPool;
        private const int ObjectPoolMaxSize = 30;
        private const int DefaultCapacity = 10;

        private void Start()
        {
            _imageEffectPool = new ObjectPool<ImageEffect>(
                OnCreatePoolObject, // createFunc
                OnTakeFromPool, // actionOnGet
                OnReturnedToPool, // actionOnRelease
                OnDestroyPoolObject, // actionOnDestroy
                true, // collectionCheck
                DefaultCapacity, // defaultCapacity
                ObjectPoolMaxSize // maxSize
            );
        }

        private static void OnTakeFromPool(ImageEffect obj)
        {
            obj.Reset();
            obj.gameObject.SetActive(true);
        }

        private ImageEffect OnCreatePoolObject()
        {
            return Instantiate(imageEffect);
        }

        private static void OnDestroyPoolObject(ImageEffect obj)
        {
            Destroy(obj.gameObject);
        }

        private static void OnReturnedToPool(ImageEffect obj)
        {
            obj.gameObject.SetActive(false);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var image = _imageEffectPool.Get();
                await image.Move(new ImageInfo());
                _imageEffectPool.Release(image);
            }
        }
    }
}