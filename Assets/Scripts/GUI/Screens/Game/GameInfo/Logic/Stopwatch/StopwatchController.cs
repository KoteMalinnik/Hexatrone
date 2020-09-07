using UnityEngine.UI;
using UnityEngine;

namespace CustomScreen.Logic
{
    public class StopwatchController : MonoBehaviour
    {
        #region Fields
        [SerializeField] Text seconds = null;
        [SerializeField] Text minutes = null;

        Stopwatch stopwatch = new Stopwatch();

#if UNITY_EDITOR
        [SerializeField] bool runStopwatchOnAwake = false;
#endif
        #endregion

        #region MonoBehaviour Callbacks
        void Awake()
        {
#if UNITY_EDITOR
            if (runStopwatchOnAwake)
            {
                RunStopwatch();
            }
#endif
        }

        private void OnEnable()
        {
            Statements.OnPause += StopStopwatch;
            Statements.OnUnpause += RunStopwatch;
        }

        private void OnDisable()
        {
            Statements.OnPause -= StopStopwatch;
            Statements.OnUnpause -= RunStopwatch;
        }
        #endregion

        private void RunStopwatch()
        {
            Log.Message("Запуск секундомера.");
            InvokeRepeating(nameof(UpdateUI), 0, 1);
        }

        private void StopStopwatch()
        {
            Log.Message("Остановка секундомера.");
            CancelInvoke();
        }

        private void UpdateUI()
        {
            //Log.Message("UpdateUI " + stopwatch.ToString());

            seconds.text = stopwatch.Second.ToString("00");
            minutes.text = stopwatch.Minute.ToString("00");

            stopwatch.AddSecond();
        }
    }
}