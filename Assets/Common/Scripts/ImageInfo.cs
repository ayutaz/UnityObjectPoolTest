using UnityEngine;

namespace Common
{
    public class ImageInfo
    {
        public Color Color { get; private set; }
        public Vector2 MoveValue { get; private set; }
        public float LifeTime { get; private set; }
        public float MoveSpeed { get; private set; }

        public ImageInfo(Color color, Vector2 moveValue, float lifeTime, float moveSpeed)
        {
            Color = color;
            MoveValue = moveValue;
            LifeTime = lifeTime;
            MoveSpeed = moveSpeed;
        }

        public ImageInfo()
        {
            Color = RandomValue.RandomColor();
            MoveValue = RandomValue.RandomVector2Value(-1f, 1f);
            LifeTime = Random.Range(1f, 5f);
            MoveSpeed = Random.Range(1f, 5f);
        }
    }
}