using UnityEngine;

namespace Util
{
    public static class RandomValue
    {
        public static Color RandomColor()
        {
            var random = Random.Range(0, 4);
            return random switch
            {
                0 => Color.red,
                1 => Color.green,
                2 => Color.blue,
                3 => Color.yellow,
                _ => Color.white
            };
        }

        public static Vector2 RandomVector2Value(float min, float max)
        {
            return new Vector2(Random.Range(min, max), Random.Range(min, max));
        }
    }
}