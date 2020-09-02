using UnityEngine;

namespace Orb
{
    [RequireComponent(typeof(OrbGenerator))]
    [RequireComponent(typeof(OrbColorizer))]
    public class OrbGeneratingController : MonoBehaviour
    {
        #region Fields
        OrbGenerator generator = null;
        OrbColorizer colorizer = null;

        int maxColorLevel = 3;
        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            Form.FormLevelController.OnFormLevelChange += ChangeMaxColorLevel;
            OrbDataController.OnOrbCollision += GenerateNewOrb;
        }

        private void OnDisable()
        {
            Form.FormLevelController.OnFormLevelChange -= ChangeMaxColorLevel;
            OrbDataController.OnOrbCollision -= GenerateNewOrb;
        }
        #endregion

        void ChangeMaxColorLevel(int formLevel)
        {
            maxColorLevel = formLevel + 2;
        }

        public void GenerateNewOrb(OrbData e = null)
        {
            var orb = generator.Generate();
            var orbDataController = orb.GetComponent<OrbDataController>();
            var color = colorizer.Colorize(orb, maxColorLevel);
            orbDataController.Initialize(new OrbData(1, color));
        }
    }

}