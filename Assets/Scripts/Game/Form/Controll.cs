using UnityEngine;

namespace Form
{
	[RequireComponent(typeof(Rotation))]
	public class Controll : MonoBehaviour
	{
		#region Fields
		[SerializeField] float rotationSpeed = 1;
		#endregion

		#region MonoBehaviour Callbacks
		private void OnEnable()
        {
			Part.MouseKeyDownHandler.OnPartClick += CalculateRotation;
        }

        private void OnDisable()
        {
			Part.MouseKeyDownHandler.OnPartClick -= CalculateRotation;
		}
        #endregion

        void CalculateRotation(Transform partTransform)
		{
			Log.Message("Рассчет угла поворота формы.");

			Quaternion formRotation = partTransform.parent.rotation;
			Quaternion partRotation = partTransform.localRotation;

			/*
			 * Алгоритм поворота нажатой части вверх:
			 * 1. Повернуть форму так, чтобы нажатая часть оказалась внизу.
			 *		Для этого надо повернуть форму на локальный поворот нажатой части.
			 * 2. Повернуть форму на 180 градусов.
			 */

			formRotation *= partRotation;
			formRotation *= Quaternion.Euler(0, 0, 180);

			//TODO: добавить учет направления к сфере

			Rotate(partTransform.parent, formRotation.eulerAngles.z);
		}

		void Rotate(Transform formTransform, float rotationAngle)
        {
			GetComponent<Rotation>().RotateByAngle(formTransform, angleZ: rotationAngle);
		}
	}
}