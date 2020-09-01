using System;
using System.Collections;
using UnityEngine;

namespace Form
{
	public class FormRotation : MonoBehaviour
	{
		#region Fields
		CommonCoroutine rotationRoutine = null;
		#endregion

        /// <summary>
        /// Вращение объекта. Положительный угол оси Z соответствует вращению по часовой стрелке.
        /// </summary>
        public void RotateByAngle(
			Transform formTransform,
			float angleY = 0,
			float angleZ = 0,
			float rotationSpeed = 1,
			Action OnFinish = null)
		{
			if (rotationRoutine != null)
			{
				Log.Message("Корутина вращения уже запущена.");
				return;
			}

			Log.Message($"Вращение формы на углы: Y = {angleY}, Z = {angleZ}");

			//-angleZ, чтобы вращался по часовой. Привычно для понимания
			rotationRoutine = new CommonCoroutine(this, () => Rotate(formTransform, angleY, -angleZ, rotationSpeed));
			rotationRoutine.OnFinish += OnFinish;
			rotationRoutine.OnFinish += () => rotationRoutine = null;
			rotationRoutine.Start();
		}

		IEnumerator Rotate(Transform formTransform, float angleY, float angleZ, float rotationSpeed)
		{
			Log.Message("Начало вращения.");

			var targetRotation = formTransform.rotation * Quaternion.Euler(0.0f, angleY, angleZ);

			for (float T = 0.00f;
				Quaternion.Angle(formTransform.rotation, targetRotation) > 0.1f;
				T += rotationSpeed * Time.deltaTime)
			{
				formTransform.rotation = Quaternion.Lerp(formTransform.rotation, targetRotation, T);
				yield return new WaitForEndOfFrame();
			}

			formTransform.rotation = targetRotation;

			rotationRoutine = null;
			Log.Message("Конец вращения.");
		}
	}
}