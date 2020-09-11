using UnityEngine;
using UnityEngine.UI;
using OrbCounters;
using Form;

namespace CustomScreen.Logic
{
    public class MissedOrbsAtFormLevelSliderController : SliderController
    {
        #region Fields
        [SerializeField] Color zeroLevelColor = Color.gray;
        #endregion

        #region Overrided Methods
        protected override void OnEnable()
        {
            MissedOrbsAtFormLevelCounter.OnValueChanged += UpdateValue;
            MissedOrbsAtFormLevelCounter.OnCounterReset += UpdateMaxValue;

            FormLevelController.OnFormLevelChange += UpdateColor;
        }

        protected override void OnDisable()
        {
            MissedOrbsAtFormLevelCounter.OnValueChanged -= UpdateValue;
            MissedOrbsAtFormLevelCounter.OnCounterReset -= UpdateMaxValue;

            FormLevelController.OnFormLevelChange -= UpdateColor;
        }

        protected override void UpdateValue(int delta = 1)
        {
            Log.Message("Обновление значения слайдера MissedOrbsAtFormLevelSliderController.");
            Slider.value -= delta;
        }

        protected override void UpdateColor(int formLevel)
        {
            Log.Message("Обновление цвета слайдера MissedOrbsAtFormLevelSliderController.");

            if (formLevel -2 < 0)
            {
                FillRectImage.color = zeroLevelColor;
            }
            else
            {
                FillRectImage.color = ColorSet.GetColor(formLevel + 1);
            }
        }

        protected override void UpdateMaxValue(int orbsCountAllowedToMiss)
        {
            Log.Message("Обновление максимального значения слайдера MissedOrbsAtFormLevelSliderController: " + orbsCountAllowedToMiss);
            Slider.maxValue = orbsCountAllowedToMiss;
            Slider.value = orbsCountAllowedToMiss;
        }
        #endregion
	}
}