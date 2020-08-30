using System;
using UnityEngine;

namespace Form
{
	public static class Destroyer
	{
        #region Events
        public static event Action OnFormDestroyed = null;
        #endregion

        public static void DestroyForm (GameObject form, Rotation rotationAnimation)
        {
            Log.Message("Уничтожение формы: " + form.name);

            if (form == null)
            {
                Log.Message("Форма отсутствует.");
                return;
            }    

            rotationAnimation.RotateByAngle
                (
                form.transform,
                angleY: 90,
                rotationSpeed: 5,
                OnFinish: () =>
                {
                    MonoBehaviour.Destroy(form);
                    Log.Message($"Форма {form.name} уничтожена");
                    OnFormDestroyed?.Invoke();
                }
                );
		}
    }
}