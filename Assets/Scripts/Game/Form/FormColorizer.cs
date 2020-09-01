using UnityEngine;

namespace Form
{
    public class FormColorizer : MonoBehaviour
    {
        //TODO: использовать SerializedObject
        [SerializeField] Color[] partColors = new Color[6];
        
        public void ColorizeForm(GameObject form)
        {
            Log.Message("Установка цветов частей формы.");

            Transform formTransform = form.transform;
            for (int i = 0; i < formTransform.childCount; i++)
            {
                ColorizePart(formTransform.GetChild(i), partColors[i]);
            }
        }

        void ColorizePart(Transform partTransform, Color color)
        {
            var partColorController = partTransform.GetComponent<ColorController>();
            partColorController.SetColor(color);
        }
    }
}