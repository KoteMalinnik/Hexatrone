using System;
using UnityEngine;

namespace Form
{
	public static class Instantiator
	{
		#region Events
		public static event Action OnFormInstantiated = null;
        #endregion

        public static GameObject InstantiateForm
			(
			GameObject prefab,
			Transform parent,
			Vector2 position,
			Rotation rotationAnimation
			)
		{
			Log.Message("Создание формы: " + prefab?.name);

			if (prefab == null)
            {
				Log.Warning("Префаб пуст.");
				return null;
            }

			GameObject form = MonoBehaviour.Instantiate(prefab, position, Quaternion.Euler(0, 90, 0), parent);
			
			rotationAnimation.RotateByAngle
				(
				form.transform,
				angleY: -90,
				rotationSpeed: 1,
				OnFinish: () => OnFormInstantiated?.Invoke()
				);

			return form;
		}
	}
}