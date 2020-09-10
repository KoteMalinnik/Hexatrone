using UnityEngine;
using System.Collections;
using System;
using Orb;

namespace OrbCollision
{
    public class OrbCollisionHandler : MonoBehaviour
    {
		#region Events
		public static event Action OnMatch = null;
		public static event Action OnMismatch = null;
		#endregion

		#region Fields
		CommonCoroutine waitForLateUpdateRoutine = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
			OrbCollisionListener.OnCollision += TrackCollision;
        }

        private void OnDisable()
        {
			OrbCollisionListener.OnCollision -= TrackCollision;
		}
        #endregion

		void TrackCollision(CollisionData data)
        {
			Log.Message("Отслеживание коллизии.");
			var checker = new OrbDoubleCollisionChecker(data);

			if (waitForLateUpdateRoutine != null) return;
			
			waitForLateUpdateRoutine = new CommonCoroutine(this, WaitForLateUpdate);
			waitForLateUpdateRoutine.OnFinish += () =>
			{
				if (checker.DoubleCollision) DoubleCollision(checker.Collision_1, checker.Collision_2);
				else SingleCollision(checker.Collision_1);

				waitForLateUpdateRoutine = null;
				OrbDoubleCollisionChecker.ClearCollisionData();
			};

			Log.Message("Запуск корутины ожидания.");
			waitForLateUpdateRoutine.Start();
		}

		IEnumerator WaitForLateUpdate()
		{
			yield return new WaitForEndOfFrame();
		}

		void DoubleCollision(CollisionData collision_1, CollisionData collision_2)
        {
			Log.Message("Обработка двойного столкновение.");
			Log.Message("Поиск наилучшего совпадения.");

			if (CheckColorsMatch(collision_1))
            {
				ColorsMatch(collision_1.PartFlashing);
				return;
			}
			else
			if (CheckColorsMatch(collision_2))
            {
				ColorsMatch(collision_2.PartFlashing);
				return;
			}

			Log.Message("Совпадений не найдено.");
			ColorsMismatch(collision_1.PartFlashing);
		}

		void SingleCollision(CollisionData collision)
        {
			Log.Message("Обработка одиночного столкновения.");

			if (CheckColorsMatch(collision))
            {
				ColorsMatch(collision.PartFlashing);
				return;
            }

			Log.Message("Совпадений не найдено.");
			ColorsMismatch(collision.PartFlashing);
		}

		bool CheckColorsMatch(CollisionData collision)
        {
			Log.Message("Проверка цветов коллизии на совпадение.");
			bool match = collision.PartColor.Equals(collision.OrbColor);
			Log.Message("Результат проверки: " + match);
			return match;
		}

		void ColorsMatch(Part.PartFlashing flashing)
        {
			Log.Message("Совпадение цветов части и сферы!");
			flashing.Flash(true);
			OnMatch?.Invoke();
		}

		void ColorsMismatch(Part.PartFlashing flashing)
		{
			Log.Message("Несовпадение цветов части и сферы.");
			flashing.Flash(false);
			OnMismatch?.Invoke();
		}
	}
}