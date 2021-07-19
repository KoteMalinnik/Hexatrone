using Form;

namespace CustomScreen.Logic
{
    public class FormLevelTextViewer : IntTextViewer
    {
        #region Overrided Methods
        protected override void OnEnable()
        {
            FormLevelController.OnFormLevelChange += UpdateText;
        }

        protected override void OnDisable()
        {
            FormLevelController.OnFormLevelChange -= UpdateText;
        }

        protected override void UpdateText(int formLevel)
        {
            Log.Message("Обновление текста " + typeof(FormLevelTextViewer));
            TextValue.text = formLevel.ToString();
        }
        #endregion
    }
}