//using UnityEngine;

//namespace Orb
//{
//    public class OrbColorizer : MonoBehaviour
//    {
//        [SerializeField] ColorSet partColors = null;

//        public Color Colorize(GameObject orb, int maxColorLevel)
//        {
//            var spriteRenderer = orb.GetComponent<SpriteRenderer>();
//            spriteRenderer.color = GetRandomColor(maxColorLevel);
//            Log.Message("Установка цвета сферы: " + spriteRenderer.color);
//            return spriteRenderer.color;

//        }

//        Color GetRandomColor(int maxColorLevel)
//        {
//            int index = Random.Range(0, maxColorLevel);
//            return partColors.GetColor(index);
//        }
//    }
//}