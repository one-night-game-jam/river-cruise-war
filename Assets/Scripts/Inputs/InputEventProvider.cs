using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Inputs
{
    public class InputEventProvider : MonoBehaviour
    {
        public IObservable<Unit> Drive => this.UpdateAsObservable()
                .Where(_ => this.GetDrive())
                .AsUnitObservable()
                .Share()
                .TakeUntilDestroy(this);

        private bool GetDrive()
        {
            return Input.GetButtonDown("Drive");
        }
    }
}