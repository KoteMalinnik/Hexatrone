using UnityEngine;

namespace Orb
{
    public class OrbColorizer : MonoBehaviour
    {
        [SerializeField] ColorSet partColors = null;

        public void Colorize(GameObject orb, int maxColorLevel)
        {
            Log.Message("Установка цвета сферы.");

            var spriteRenderer = orb.GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetRandomColor(maxColorLevel);

        }

        Color GetRandomColor(int maxColorLevel)
        {
            int index = Random.Range(0, maxColorLevel);
            return partColors.GetColor(index);
        }
    }
}