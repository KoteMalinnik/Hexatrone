using UnityEngine;

namespace OrbCollision
{
	public class CollisionData
	{
        #region Properties
        public Color PartColor { get; }
        public Color OrbColor { get; }

        public Part.PartFlashing PartFlashing { get; }
        #endregion

        public CollisionData(Color PartColor, Color OrbColor, Part.PartFlashing PartFlashing)
        {
            this.PartColor = PartColor;
            this.OrbColor = OrbColor;

            this.PartFlashing = PartFlashing;
        }
    }
}