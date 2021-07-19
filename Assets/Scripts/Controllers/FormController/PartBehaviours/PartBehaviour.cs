using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace FormController
{
    public class PartBehaviour: MonoBehaviour
    {
        // --- Fields ---

        [SerializeField] private UnityEvent onClick;


        void OnMouseDown()
        {
            if (Statements.Pause) return;

            Log.Message($"Нажатие на {name}.");
            OnClick?.Invoke(transform);
        }

        // --- Properties ---

        // --- Methods ---

        // --- Callbacks ---

        private void OnClick()
        {
            Log.Message($"Нажатие на часть {gameObject.name}");
        }
    }
}