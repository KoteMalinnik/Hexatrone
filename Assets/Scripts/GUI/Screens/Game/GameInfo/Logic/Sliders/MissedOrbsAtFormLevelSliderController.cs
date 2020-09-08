using UnityEngine;
using UnityEngine.UI;
using OrbCounters;
using Form;
using OrbCollision;

namespace CustomScreen.Logic
{
    public class MissedOrbsAtFormLevelSliderController : MonoBehaviour
    {
        #region Fields
        [SerializeField] Slider slider = null;
        Image fillRectImage = null;

        [SerializeField] ColorSet colorSet = null;
        [SerializeField] Color zeroLevelColor = Color.gray;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            fillRectImage = slider.fillRect.GetComponent<Image>();
        }

        private void OnEnable()
        {
            OrbCollisionHandler.OnMismatch += UpdateValue;
            MissedOrbsAtFormLevelCounter.OnCounterReset += UpdateMaxValue;
            FormLevelController.OnFormLevelChange += UpdateColor;
        }

        private void OnDisable()
        {
            OrbCollisionHandler.OnMismatch -= UpdateValue;
            MissedOrbsAtFormLevelCounter.OnCounterReset -= UpdateMaxValue;
            FormLevelController.OnFormLevelChange -= UpdateColor;
        }
        #endregion

        #region Slider Update
        void UpdateValue()
        {
            Log.Message("Обновление значения слайдера MissedOrbsAtFormLevelSliderController.");
            slider.value--;
        }

        void UpdateColor(int formLevel)
        {
            Log.Message("Обновление цвета слайдера MissedOrbsAtFormLevelSliderController.");

            if (formLevel -2 < 0)
            {
                fillRectImage.color = zeroLevelColor;
            }
            else
            {
                fillRectImage.color = colorSet.GetColor(formLevel + 1);
            }
        }

        void UpdateMaxValue(int orbsCountAllowedToMiss)
        {
            Log.Message("Обновление максимального значения слайдера MissedOrbsAtFormLevelSliderController: " + orbsCountAllowedToMiss);
            slider.maxValue = orbsCountAllowedToMiss;
            slider.value = orbsCountAllowedToMiss;
        }
        #endregion
	}
}