using UnityEngine;

namespace Orb
{
    [RequireComponent(typeof(OrbGenerator))]
    [RequireComponent(typeof(OrbColorizer))]
    public class OrbGeneratingController : MonoBehaviour
    {
        #region Fields
        int maxColorLevel = 3;
        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            Form.FormLevelController.OnFormLevelChange += ChangeMaxColorLevel;
        }

        private void OnDisable()
        {
            Form.FormLevelController.OnFormLevelChange -= ChangeMaxColorLevel;
        }
        #endregion

        void ChangeMaxColorLevel(int formLevel)
        {
            maxColorLevel = formLevel + 2;
        }

        public void GenerateNewOrb()
        {
            var orb = GetComponent<OrbGenerator>().Generate();
            var color = GetComponent<OrbColorizer>().Colorize(orb, maxColorLevel);
        }
    }

}