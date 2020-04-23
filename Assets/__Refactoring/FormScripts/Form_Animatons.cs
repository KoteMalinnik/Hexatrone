using System.Collections;
using UnityEngine;

/*

	ОТВЕЧАЕТ ЗА АНИМАЦИЮ НОВОГО УРОВНЯ И ПОВОРОТА ФОРМЫ ПРИ УПРАВЛЕНИИ PART_SELECTED

 */

public class Form_Animatons : MonoBehaviour
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

	////анимация мигания для части
	//public IEnumerator partAnimation(SpriteRenderer sr, Color startColor, Color endColor)
	//{
	//	float T = 0f;
	//	float intensity = gm._formParametrs.partIntensity;

	//	while (true)
	//	{
	//		sr.color = Color.Lerp(startColor, endColor, T);
	//		T += 0.01f * intensity;

	//		//цвет достиг заданного
	//		if (sr.color == endColor)
	//		{
	//			T = 0;

	//			while (true)
	//			{
	//				sr.color = Color.Lerp(endColor, startColor, T);
	//				T += 0.01f * intensity;

	//				//цвет достиг заданного
	//				if (sr.color == startColor)
	//				{
	//					gm._formProcessingOrbs.partAnimationCoroutine = null;
	//					yield break;
	//				}
	//				yield return null;
	//			}
	//		}
	//		yield return null;
	//	}
	//}

}
