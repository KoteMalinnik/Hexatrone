using UnityEngine;

namespace Orb
{
	public class OrbMovement : MonoBehaviour
	{
		#region Fields
		bool allowMovement = true;
		Transform cachedTransform = null;

		[Range(0.01f, 10f)]
		[SerializeField] float movementSpeed = 2f;
		[SerializeField] Vector3 targetPosition = new Vector3(0, -9, 0);
		#endregion

		void Awake()
		{
			cachedTransform = transform;
		}

		void Update()
		{
			if (allowMovement)
			{
				var currentPosition = cachedTransform.localPosition;
				currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
				cachedTransform.localPosition = currentPosition;
			}
		}

		public void AllowMovement()
        {
			Log.Message("Разрешение перемещения сферы.");
			allowMovement = true;
        }

		public void DisallowMovement()
        {
			Log.Message("Запрет перемещения сферы.");
			allowMovement = false;
		}
	}
}