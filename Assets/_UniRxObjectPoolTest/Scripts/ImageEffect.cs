using System;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using Util;

namespace _UniRxObjectPoolTest
{
    public class ImageEffect : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _isMove;
        private float _moveSpeed;
        [SerializeField, ReadOnly] private Vector3 moveDirection;

        public void Reset()
        {
            transform.position = Vector3.zero;
            moveDirection = Vector3.zero;
            _isMove = false;
            // _spriteRenderer.color = Color.white;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!_isMove) return;
            transform.Translate(moveDirection * Time.deltaTime * _moveSpeed);
        }

        public UniTask Move(ImageInfo imageInfo)
        {
            _isMove = true;
            moveDirection = imageInfo.MoveValue;
            _moveSpeed = imageInfo.MoveSpeed;
            _spriteRenderer.color = imageInfo.Color;
            return UniTask.Delay(TimeSpan.FromSeconds(imageInfo.LifeTime));
        }
    }
}