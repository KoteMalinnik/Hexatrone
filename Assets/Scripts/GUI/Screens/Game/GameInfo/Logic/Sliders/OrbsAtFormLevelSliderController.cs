using UnityEngine;
using UnityEngine.UI;
using OrbCounters;
using Form;

namespace CustomScreen.Logic
{
    public class OrbsAtFormLevelSliderController : MonoBehaviour
    {
        #region Fields
        [SerializeField] Slider slider = null;
        Image fillRectImage = null;

        [SerializeField] ColorSet colorSet = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            fillRectImage = slider.fillRect.GetComponent<Image>();
            UpdateValue(0);
        }

        private void OnEnable()
        {
            FormLevelController.OnFormMaxLevel += HideSlider;
            FormLevelController.OnFormLevelChange += ShowSlider;
            
            FormLevelController.OnFormLevelChange += UpdateColor;
            CollectedOrbsAtFormLevelCounter.OnNewOrbCollected += UpdateValue;
            CollectedOrbsAtFormLevelCounter.OnCounterReset += UpdateMaxValue;
        }

        private void OnDisable()
        {
            FormLevelController.OnFormMaxLevel -= HideSlider;
            FormLevelController.OnFormLevelChange -= ShowSlider;
            
            FormLevelController.OnFormLevelChange -= UpdateColor;
            CollectedOrbsAtFormLevelCounter.OnNewOrbCollected -= UpdateValue;
            CollectedOrbsAtFormLevelCounter.OnCounterReset -= UpdateMaxValue;
        }
        #endregion

        #region Slider Update
        void UpdateValue(int collectedOrbsCount)
        {
            Log.Message("Обновление значения слайдера OrbsAtFormLevelSliderController.");
            slider.value = collectedOrbsCount;
        }

        void UpdateColor(int formLevel)
        {
            Log.Message("Обновление цвета слайдера OrbsAtFormLevelSliderController.");
            try
            {
                ShowSlider();
                fillRectImage.color = colorSet.GetColor(formLevel + 2);
            }
            catch
            {
                HideSlider();
            }
        }

        void UpdateMaxValue(int orbsCountToNextFormLevel)
        {
            Log.Message("Обновление максимального значения слайдера OrbsAtFormLevelSliderController.");
            slider.maxValue = orbsCountToNextFormLevel;
        }
        #endregion

        void HideSlider()
        {
            Log.Message("Сокрытие слайдера OrbsAtFormLevelSliderController.");
            slider.gameObject.SetActive(false);
        }

        void ShowSlider(int e = 0)
        {
            if (slider.isActiveAndEnabled) return;
            Log.Message("Показ слайдера OrbsAtFormLevelSliderController.");
            slider.gameObject.SetActive(true);
            UpdateValue(0);
        }
	}
}