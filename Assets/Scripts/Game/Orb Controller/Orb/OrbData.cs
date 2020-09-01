using UnityEngine;

namespace Orb
{
	public class OrbData
	{
        #region Properties
        public int Delta { get; }
        public Color Color { get; }
        #endregion

        public OrbData(int Delta, Color Color)
        {
            Log.Message("Установка дельты сферы: " + Delta);
            this.Delta = Delta;
            this.Color = Color;
        }
    }
}