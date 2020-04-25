using UnityEngine;

public class FormPartSelection : MonoBehaviour
{
	static Transform cachedTransform = null;
	void Awake()
	{
		cachedTransform = transform;
	}

	/// <summary>
	/// Calculate angle and rotate form.
	/// </summary>
	public static void calculate(float partLocalRotation)
	{
		if (FormRotation.rotating) return;

		Debug.Log("[PartSelection] Рассчитать угол поворота.");

		//Преобразование локального угла поворота части формы таким образом,
		//что если это левая часть, то ее локальный угол поворота будет отрицательным в пределах [0; -180]
		//и отсчитывается от Vector2.down

		//На примере треугольной формы: нижняя часть имеет локальный угол поворота 0, левая 120, правая -120
		//но не: нижняя 0, левая 120, правая 240
		if (partLocalRotation > 180) partLocalRotation -= 360;

		//Преобразование глобального угла поворота формы таким образом,
		//что если условный нос формы лежит левее Vector2.up, то он положительный в пределах [0; 180]
		float rotation = cachedTransform.localRotation.eulerAngles.z;
		if (rotation > 180) rotation -= 360;

		//вектор направления от формы к сфере
		Vector2 directionToOrb = OrbController.orbTransform.position - cachedTransform.position;
		//угло между вектором направления и Vector2.Up. Положительный в левой части
		float alpha = Vector2.SignedAngle(Vector2.up, directionToOrb);

		//Практическим путем, потом и слезами, было выведено соотношение:
		float targetAngle = 180 - partLocalRotation + alpha;
		//Пояснение. Поскольку часть, локальный угол поворота которой равен 0, лежит напротив глобального угла поворота,
		//то необходимо прибавить 180 градусов
		//чтобы повернуть форму частью вверх, надо отнять локальный угол поворота части
		//Выравнивание по направлению к сфере с помощью угла alpha

		FormRotation.rotate(0, targetAngle);
	}
}