using UI.CustomScreen;
using UnityEngine;

namespace Orb
{
    [RequireComponent(typeof(OrbGenerator))]
    [RequireComponent(typeof(OrbColorizer))]
    public class OrbGeneratingController : MonoBehaviour
    {
        [Range(0, 10)]
        [SerializeField] float orbGeneratingInterval = 1;

        int maxColorLevel = 3;


        private void OnEnable()
        {
            PrepareTapScreen.OnPrepareTapButtonDown += StartGeneration;
            Statements.OnGameOver += StopGeneration;

            Form.FormLevelController.OnFormLevelChange += ChangeMaxColorLevel;
        }

        private void OnDisable()
        {
            PrepareTapScreen.OnPrepareTapButtonDown -= StartGeneration;
            Statements.OnGameOver -= StopGeneration;

            Form.FormLevelController.OnFormLevelChange -= ChangeMaxColorLevel;
        }

        private void ChangeMaxColorLevel(int formLevel)
        {
            maxColorLevel = formLevel + 2;
        }

        public void GenerateNewOrb()
        {
            var orb = GetComponent<OrbGenerator>().Generate();
            var color = GetComponent<OrbColorizer>().Colorize(orb, maxColorLevel);
        }

        void StartGeneration()
        {
            InvokeRepeating(nameof(GenerateNewOrb), 0, orbGeneratingInterval);
        }

        void StopGeneration()
        {
            CancelInvoke();
        }
    }
}