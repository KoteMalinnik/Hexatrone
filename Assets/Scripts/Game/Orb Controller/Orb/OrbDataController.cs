using UnityEngine;
using System;

namespace Orb
{
    public class OrbDataController : MonoBehaviour
    {
        #region Events
        public static event Action<OrbData> OnOrbCollision = null;
        #endregion

        #region Fields
        OrbData data = null;
        #endregion

        public void Initialize(OrbData data)
        {
            this.data = data;
        }

        private void OnDestroy()
        {
            Log.Message("Уничтожение сферы.");
            OnOrbCollision?.Invoke(data);
        }
    }
}