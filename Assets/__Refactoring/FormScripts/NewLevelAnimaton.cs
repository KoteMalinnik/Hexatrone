using System.Collections;
using UnityEngine;

/// <summary>
/// New level animaton.
/// </summary>
public class NewLevelAnimaton : MonoBehaviour
{
	////анимация вращения
	//public IEnumerator c_Rotate(float angleY, float angleZ, float intensity) //angle - угол поворота, intensity - скорость поворота
	//{
	//	var me = gameObject.transform; //начальный transform
	//	var to = Quaternion.Euler(0.0f, angleY, angleZ); //требуемый rotation

	//	while (true)
	//	{
	//		me.rotation = Quaternion.Lerp(me.rotation, to, intensity * Time.deltaTime);

	//		//если угол между требуемым и измененным положением практически совпадает, то отключаем анимацию
	//		if (Quaternion.Angle(me.rotation, to) < 0.1f)
	//		{
	//			Form_Parametrs.instance.Coroutine_Rotate = null;
	//			Form_Parametrs.instance.rotate_SelectedPart = null;
	//			me.rotation = to;

	//			yield break;
	//		}

	//		yield return null;
	//	}
	//}
}
