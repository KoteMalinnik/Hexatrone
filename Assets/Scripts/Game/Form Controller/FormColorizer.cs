using UnityEngine;

namespace Form
{
    public class FormColorizer : MonoBehaviour
    {
        [SerializeField] ColorSet partColors = null;

        public void Colorize(GameObject form)
        {
            Log.Message("Установка цветов частей формы.");

            Transform formTransform = form.transform;
            if (partColors.Lenght != formTransform.childCount)
            {
                Log.Error("Количество частей и цветов не совпадает.");
                return;
            }

            for (int i = 0; i < partColors.Lenght; i++)
            {
                var spriteRenderer = formTransform.GetChild(i).GetComponent<SpriteRenderer>();
                spriteRenderer.color = partColors.GetColor(i);
            }
        }
    }
}