using UniRx.Toolkit;
using UnityEngine;

namespace _UniRxObjectPoolTest
{
    public class ImagePool : ObjectPool<ImageEffect>
    {
        private readonly ImageEffect _imageEffect;
        private readonly Transform _parentTransform;

        public ImagePool(ImageEffect imageEffect, Transform parentTransform)
        {
            _imageEffect = imageEffect;
            _parentTransform = parentTransform;
        }

        protected override ImageEffect CreateInstance()
        {
            return Object.Instantiate(_imageEffect, _parentTransform);
        }

        protected override void OnBeforeRent(ImageEffect instance)
        {
            instance.Reset();
            base.OnBeforeRent(instance);
        }
    }
}