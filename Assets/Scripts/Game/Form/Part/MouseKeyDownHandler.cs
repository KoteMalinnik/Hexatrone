using System;
using UnityEngine;

namespace Part
{
	public class MouseKeyDownHandler : MonoBehaviour
	{
		public static event Action<Transform> OnPartClick = null;

		void OnMouseDown()
		{
			if (Statements.pause) return;

			Log.Message($"Нажатие на {name}.");
			OnPartClick?.Invoke(transform);
		}
	}
}