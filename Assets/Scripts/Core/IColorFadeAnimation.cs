using System;
using UnityEngine;

namespace PartBehaviour
{
    interface IColorFadeAnimation
    {
        event Action OnAnimationFinished;

        void SetTargetColor(Color color);
        void Start();
    }
}