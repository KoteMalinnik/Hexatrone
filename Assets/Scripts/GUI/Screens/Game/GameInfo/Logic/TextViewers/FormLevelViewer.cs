using UnityEngine;
using UnityEngine.UI;
using Form;

namespace CustomScreen.Logic
{
    public class FormLevelViewer : MonoBehaviour
    {
        #region Fields
        [SerializeField] Text text_value = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
            FormLevelController.OnFormLevelChange += UpdateText;
        }

        private void OnDisable()
        {
            FormLevelController.OnFormLevelChange -= UpdateText;
        }
        #endregion

        #region Text Update
        void UpdateText(int formLevel)
        {
            Log.Message("Обновление текста FormLevelViewer.");
            text_value.text = formLevel.ToString();
        }
        #endregion
    }
}