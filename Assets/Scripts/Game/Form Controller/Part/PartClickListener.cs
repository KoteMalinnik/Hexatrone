using System;
using UnityEngine;

namespace Part
{
	public class PartClickListener : MonoBehaviour
	{
		public static event Action<Transform> OnClick = null;

		void OnMouseDown()
		{
			if (Statements.pause) return;

			Log.Message($"Нажатие на {name}.");
			OnClick?.Invoke(transform);
		}
	}
}