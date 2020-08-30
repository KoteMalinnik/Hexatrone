using UnityEngine;

namespace Orb
{
	public class Movement : MonoBehaviour
	{
		#region Fields
		[Range(0.01f, 10f)]
		[SerializeField] float movementSpeed = 2f;

		[SerializeField] Vector3 targetPosition = new Vector3(0, -9, 0);

		Transform cachedTransform = null;
		#endregion

		void Awake()
		{
			cachedTransform = transform;
		}

		void Update()
		{
			if (!Statements.pause)
			{
				var currentPosition = cachedTransform.localPosition;
				currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
				cachedTransform.localPosition = currentPosition;
			}
		}
	}
}