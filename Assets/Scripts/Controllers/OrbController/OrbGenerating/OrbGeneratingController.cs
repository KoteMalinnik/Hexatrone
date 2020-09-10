﻿using UnityEngine;

namespace Orb
{
    [RequireComponent(typeof(OrbGenerator))]
    [RequireComponent(typeof(OrbColorizer))]
    public class OrbGeneratingController : MonoBehaviour
    {
        #region Fields
        [Range(0, 10)]
        [SerializeField] float orbGeneratingInterval = 1;

        int maxColorLevel = 3;
        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            Statements.OnPause += StopGeneration;
            Statements.OnUnpause += StartGeneration;

            Form.FormLevelController.OnFormLevelChange += ChangeMaxColorLevel;
        }

        private void OnDisable()
        {
            Statements.OnPause -= StopGeneration;
            Statements.OnUnpause -= StartGeneration;

            Form.FormLevelController.OnFormLevelChange -= ChangeMaxColorLevel;
        }
        #endregion

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
            InvokeRepeating(nameof(GenerateNewOrb), 1, orbGeneratingInterval);
        }

        void StopGeneration()
        {
            CancelInvoke();
        }
    }
}