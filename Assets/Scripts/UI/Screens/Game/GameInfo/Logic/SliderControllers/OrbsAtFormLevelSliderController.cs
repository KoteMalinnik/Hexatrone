using OrbCounters;
using Form;

namespace CustomScreen.Logic
{
    public class OrbsAtFormLevelSliderController : SliderController
    {
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            UpdateValue(0);
        }
        #endregion

        #region Overrided Methods
        protected override void OnEnable()
        {
            FormLevelController.OnFormMaxLevel += HideSlider;
            FormLevelController.OnFormLevelChange += ShowSlider;
            FormLevelController.OnFormLevelChange += UpdateColor;

            CollectedOrbsAtFormLevelCounter.OnValueChanged += UpdateValue;
            CollectedOrbsAtFormLevelCounter.OnCounterReset += UpdateMaxValue;
        }

        protected override void OnDisable()
        {
            FormLevelController.OnFormMaxLevel -= HideSlider;
            FormLevelController.OnFormLevelChange -= ShowSlider;
            FormLevelController.OnFormLevelChange -= UpdateColor;

            CollectedOrbsAtFormLevelCounter.OnValueChanged -= UpdateValue;
            CollectedOrbsAtFormLevelCounter.OnCounterReset -= UpdateMaxValue;
        }

        protected override void UpdateValue(int collectedOrbsCount)
        {
            Log.Message("Обновление значения слайдера " + typeof(OrbsAtFormLevelSliderController));
            Slider.value = collectedOrbsCount;
        }

        protected override void UpdateColor(int formLevel)
        {
            Log.Message("Обновление цвета слайдера " + typeof(OrbsAtFormLevelSliderController));
            try
            {
                ShowSlider();
                FillRectImage.color = ColorSet.GetColor(formLevel + 2);
            }
            catch
            {
                HideSlider();
            }
        }

        protected override void UpdateMaxValue(int orbsCountToNextFormLevel)
        {
            Log.Message("Обновление максимального значения слайдера " + typeof(OrbsAtFormLevelSliderController));
            Slider.maxValue = orbsCountToNextFormLevel;
        }
        #endregion

        void HideSlider()
        {
            Log.Message("Сокрытие слайдера " + typeof(OrbsAtFormLevelSliderController));
            Slider.gameObject.SetActive(false);
        }

        void ShowSlider(int e = 0)
        {
            if (Slider.isActiveAndEnabled) return;

            Log.Message("Показ слайдера " + typeof(OrbsAtFormLevelSliderController));

            Slider.gameObject.SetActive(true);
            UpdateValue(0);
        }
	}
}