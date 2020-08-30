using UnityEngine;

namespace Form
{
	[RequireComponent(typeof(Controll))]
	[RequireComponent(typeof(Rotation))]
	public class FormController : MonoBehaviour
	{
		#region Fields
		[Header("Загрузка префабов")]
		[SerializeField] string path = "Prefabs\\Forms\\";
		[SerializeField] string nameTemplate = "Level_";

		[Header("Ограничения уровня")]
		[SerializeField] int minLevel = 1;
		[SerializeField] int maxLevel = 6;

		GameObject currentForm = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
			LevelController.SetupLevelThresholds(minLevel, maxLevel);
        }

        private void OnEnable()
        {
			LevelController.OnFormLevelChange += DestroyOldForm;

		}

        private void OnDisable()
        {
			LevelController.OnFormLevelChange -= DestroyOldForm;

		}
        #endregion

		void CreateNewForm()
        {
			Log.Message("Создание новой формы.");
			Destroyer.OnFormDestroyed -= CreateNewForm;

			var prefab = PrefabLoader.Load(LevelController.Level, path, nameTemplate);
			
			var instantiatedForm = Instantiator.InstantiateForm(prefab, transform, Vector2.zero, GetComponent<Rotation>());
			currentForm = instantiatedForm ?? currentForm;
		}

		void DestroyOldForm(int e)
        {
			Log.Message("Уничтожение старой формы.");

			if (currentForm == null)
            {
				Log.Message("Старая форма отсутствует.");
				CreateNewForm();
				return;
			}

			Destroyer.OnFormDestroyed += CreateNewForm;
			Destroyer.DestroyForm(currentForm, GetComponent<Rotation>());
        }
	}
}