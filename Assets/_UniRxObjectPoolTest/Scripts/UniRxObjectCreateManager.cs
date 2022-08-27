using Common;
using UnityEngine;

namespace _UniRxObjectPoolTest
{
    public class UniRxObjectCreateManager : MonoBehaviour
    {
        [SerializeField] private ImageEffect imageEffect;
        private ImagePool _imagePool;

        private void Start()
        {
            _imagePool = new ImagePool(imageEffect, transform);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var image = _imagePool.Rent();
                await image.Move(new ImageInfo());
                _imagePool.Return(image);
            }
        }
    }
}