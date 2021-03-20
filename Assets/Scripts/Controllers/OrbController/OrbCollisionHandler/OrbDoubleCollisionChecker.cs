namespace OrbCollision
{
	public class OrbDoubleCollisionChecker
	{
		static CollisionData collision_1 = null;
		static CollisionData collision_2 = null;

		public bool DoubleCollision => (collision_1 != null) && (collision_2 != null);

		public CollisionData Collision_1 => collision_1;
		public CollisionData Collision_2 => collision_2;

        public OrbDoubleCollisionChecker(CollisionData data)
        {
			Log.Message("Добавление коллизии.");
			if (collision_1 == null)
            {
				Log.Message("Это первая коллизия.");
				collision_1 = data;
            }
            else
            {
				Log.Message("Это вторая коллизия.");
				collision_2 = data;
			}
		}

		public static void ClearCollisionData()
        {
			Log.Message("Затирание коллизий.");
			collision_1 = null;
			collision_2 = null;
        }
	}
}