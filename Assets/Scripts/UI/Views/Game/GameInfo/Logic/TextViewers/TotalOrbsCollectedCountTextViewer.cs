using OrbCounters;

namespace CustomScreen.Logic
{
    public class TotalOrbsCollectedCountTextViewer : IntTextViewer
    {
        #region Overrided Methods
        protected override void OnEnable()
        {
            CollectedOrbsInTotalCounter.OnNewOrbCollected += UpdateText;
        }

        protected override void OnDisable()
        {
            CollectedOrbsInTotalCounter.OnNewOrbCollected -= UpdateText;
        }

        protected override void UpdateText(int orbsCollecrtedInTotalCount)
        {
            Log.Message("Обновление текста " + typeof(TotalOrbsCollectedCountTextViewer));
            TextValue.text = orbsCollecrtedInTotalCount.ToString();
        }
        #endregion
    }
}