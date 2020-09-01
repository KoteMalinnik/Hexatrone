﻿using UnityEngine;

namespace Form
{
	[RequireComponent(typeof(FormRotation))]
	[RequireComponent(typeof(FormColorizer))]
	public class FormChanger : MonoBehaviour
	{
		#region Fields
		[Range(1, 10)]
		[SerializeField] float animationSpeed = 5;
		
		[Header("Загрузка префабов")]
		[SerializeField] string path = "Prefabs\\Forms\\";
		[SerializeField] string nameTemplate = "Level_";

		GameObject currentForm = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
			FormLevelController.OnFormLevelChange += DestroyOldForm;
		}

        private void OnDisable()
        {
			FormLevelController.OnFormLevelChange -= DestroyOldForm;
		}
        #endregion

		void CreateNewForm(int level, FormRotation formRotation)
        {
			Log.Message("Создание новой формы.");

			var prefab = ResourceLoader.Load<GameObject>(path, nameTemplate + level, null);
			var instantiatedForm = ObjectInstantiator.Instantiate(prefab, transform, Vector2.zero, Quaternion.Euler(0, 90, 0));
			
			if (instantiatedForm == null) return;
			currentForm = instantiatedForm;

			GetComponent<FormColorizer>().ColorizeForm(currentForm);
			formRotation.RotateByAngle(currentForm.transform, angleY: -90, rotationSpeed: animationSpeed);
		}

		void DestroyOldForm(int level)
        {
			Log.Message("Уничтожение старой формы.");

			var formRotation = GetComponent<FormRotation>();
			if (currentForm == null)
            {
				Log.Message("Старая форма отсутствует.");
				CreateNewForm(level, formRotation);
				return;
			}

			formRotation.RotateByAngle
				(
				currentForm.transform,
				angleY: 90,
				rotationSpeed: animationSpeed,
				OnFinish: () =>
				{
					MonoBehaviour.Destroy(currentForm);
					Log.Message($"Форма {currentForm.name} уничтожена");
					CreateNewForm(level, formRotation);
				}
				);
        }
	}
}