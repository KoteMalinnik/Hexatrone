using UnityEngine;
using UnityEngine.UI;
using OrbCounters;

namespace CustomScreen.Logic
{
    public class TotalOrbsCollectedCountViewer : MonoBehaviour
    {
        #region Fields
        [SerializeField] Text text_value = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
            CollectedOrbsInTotalCounter.OnNewOrbCollected += UpdateText;
        }

        private void OnDisable()
        {
            CollectedOrbsInTotalCounter.OnNewOrbCollected -= UpdateText;
        }
        #endregion

        #region Text Update
        void UpdateText(int orbsCollecrtedInTotalCount)
        {
            Log.Message("Обновление текста TotalOrbsCountViewer.");
            text_value.text = orbsCollecrtedInTotalCount.ToString();
        }
        #endregion
    }
}