using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FiveXT.Core
{
    public interface IControllable
    {
        void OnMove(InputValue value);
        void OnAim(InputValue value);
        void Action1();
        void Action2();
        void OnStart();
    }
}