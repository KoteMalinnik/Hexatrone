using UnityEngine;

namespace Form
{
	[RequireComponent(typeof(FormRotation))]
	public class FormRotationController : MonoBehaviour
	{
		[SerializeField] float rotationSpeed = 1.0f;
		[SerializeField] Transform orbGeneratorTransform = null;

		private void OnEnable()
        {
			Part.PartClickListener.OnClick += CalculateRotation;
        }

        private void OnDisable()
        {
			Part.PartClickListener.OnClick -= CalculateRotation;
		}

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

			//коррекция поворота на сферу
			if (orbGeneratorTransform.childCount > 0)
            {
				var orbTransform = orbGeneratorTransform.GetChild(0);
				Vector2 directionToOrb = orbTransform.position - partTransform.parent.position;

				Debug.DrawLine(partTransform.parent.position, (Vector2)partTransform.parent.position + directionToOrb, Color.red, 1);

				float deltaAngle = -Vector2.SignedAngle(Vector2.up, directionToOrb);
				formRotation *= Quaternion.Euler(0, 0, deltaAngle);

				Log.Message("Коррекция поворота в направлении сферы на угол: " + deltaAngle);
			}

			Rotate(partTransform.parent, formRotation.eulerAngles.z);
		}

		void Rotate(Transform formTransform, float rotationAngle)
        {
			GetComponent<FormRotation>().RotateByAngle(formTransform, angleZ: rotationAngle, rotationSpeed: rotationSpeed);
		}
	}
}