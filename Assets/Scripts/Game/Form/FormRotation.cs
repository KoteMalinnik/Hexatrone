using System;
using System.Collections;
using UnityEngine;

public class FormRotation : MonoBehaviour
{
	#region Fields
	[Range(0, 10)]
	[SerializeField] float animationSpeed = 5;

	CommonCoroutine rotationRoutine = null;
	#endregion

    /// <summary>
    /// Вращение объекта. Положительный угол оси Z соответствует вращению по часовой стрелке.
    /// </summary>
    public void RotateByAngle(GameObject form, float angleY = 0, float angleZ = 0, Action OnFinish = null)
	{
		if (rotationRoutine != null)
        {
			Log.Message("Невозможно вращать, т.к. вращение уже происходит.");
			return;
        }

		Log.Message($"Вращение формы на углы: Y = {angleY}, Z = {angleZ}");

		//var rotation = Quaternion.Euler(0.0f, angleY, angleZ);
		//form.transform.rotation = form.transform.rotation * rotation;

		//-angleZ, чтобы вращался по часовой. Привычно для понимания
		rotationRoutine = new CommonCoroutine(this, () => Rotate(form.transform, angleY, -angleZ));
		rotationRoutine.OnFinish += OnFinish;
		rotationRoutine.OnFinish += () => rotationRoutine = null;
		rotationRoutine.Start();
	}

	IEnumerator Rotate(Transform formTransform, float angleY, float angleZ)
	{
		Log.Message("Начало вращения.");

		var targetRotation = formTransform.rotation * Quaternion.Euler(0.0f, angleY, angleZ);

		for (float T = 0.00f;
			Quaternion.Angle(formTransform.rotation, targetRotation) > 0.1f;
			T += animationSpeed * Time.deltaTime)
		{
			formTransform.rotation = Quaternion.Lerp(formTransform.rotation, targetRotation, T);
			yield return new WaitForEndOfFrame();
		}

		formTransform.rotation = targetRotation;

		Log.Message("Конец вращения.");
	}
}
