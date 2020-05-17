using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FiveXT.Core
{
    public class PlayerController : MonoBehaviour, IControllable
    {
        [HideInInspector] public int playerNum;
        private List<IControllable> controlledObjects = new List<IControllable>();

        void Awake()
        {
            PlayerControllerManager.instance.RegisterPlayer(this);
            transform.SetParent(PlayerControllerManager.instance.transform);
        }

        public void AddControlledObject(IControllable controlledObject)
        {
            controlledObjects.Add(controlledObject);
        }

        public void RemoveControlledObject(IControllable controlledObject)
        {
            controlledObjects.Remove(controlledObject);
        }

        public void OnMove(InputValue value)
        {
            controlledObjects.ForEach(o => o.OnMove(value));
        }

        public void OnAim(InputValue value)
        {
            controlledObjects.ForEach(o => o.OnMove(value));
        }

        public void OnAction1()
        {
            controlledObjects.ForEach(o => o.OnAction1());
        }

        public void OnAction2()
        {
            controlledObjects.ForEach(o => o.OnAction2());
        }

        public void OnLeftTriggerAction()
        {
            controlledObjects.ForEach(o => o.OnLeftTriggerAction());
        }

        public void OnRightTriggerAction()
        {
            controlledObjects.ForEach(o => o.OnRightTriggerAction());
        }

        public void OnStart()
        {
            if (GameLobbyStarter.instance != null)
                GameLobbyStarter.instance.StartGame();
            else
                controlledObjects.ForEach(o => o.OnStart());
        }
    }
}