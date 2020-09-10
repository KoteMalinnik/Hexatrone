using UnityEngine;

namespace Orb
{
	public class OrbGenerator : MonoBehaviour
	{
		#region Fields
		[SerializeField] GameObject prefab = null;
		[SerializeField] bool randomGenerationX = true;

		float spawnPositionXThreshold = 0;
		Vector2 spawnPosition = Vector2.zero;
        #endregion

        private void Awake()
        {
			var cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
			spawnPositionXThreshold = cameraBounds.x; //область спавна не должна уходить далеко за края экрана.
			spawnPosition.y = cameraBounds.y + prefab.transform.localScale.y; //убираем сферу из области видимости при спавне

			Log.Message(
				$"Установка ограничений для генерации сфер." +
				$"По оси Х от {-spawnPositionXThreshold} до {spawnPositionXThreshold}." +
				$"По оси Y: {spawnPosition.y}."
				);
		}

        public GameObject Generate()
        {
			Log.Message("Генерация сферы.");

			if (randomGenerationX)
            {
				spawnPosition.x = Random.Range(-spawnPositionXThreshold, spawnPositionXThreshold);
			}
			else
            {
				spawnPosition.x = 0;

			}

			var generatedOrb = ObjectInstantiator.Instantiate(prefab, transform, spawnPosition, Quaternion.identity);
			Log.Message("Сфера сгенерирована в позиции " + spawnPosition);

			return generatedOrb;
		}
	}
}