using System;
using UnityEngine;
using UnityEngine.Events;

namespace PartBehaviour
{
	public class PartClickListener : MonoBehaviour
	{
		[SerializeField] private UnityEvent
		public static event Action<Transform> OnClick = null;

		void OnMouseDown()
		{
			if (Statements.Pause) return;

			Log.Message($"Нажатие на {name}.");
			OnClick?.Invoke(transform);
		}
	}
}