using UnityEngine;
using System.Collections;

namespace OrbCounters
{
    public class OrbCountersManager : MonoBehaviour
    {
        #region Fields
        CollectedOrbsInTotalCounter collectedOrbsInTotal = null;
        CollectedOrbsAtFormLevelCounter collectedOrbsAtFormLevel = null;
        MissedOrbsAtFormLevelCounter missedOrbsAtFormLevel = null;
        #endregion
    }
}