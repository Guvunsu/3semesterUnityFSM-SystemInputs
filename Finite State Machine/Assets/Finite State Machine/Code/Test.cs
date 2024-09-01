using SotomaYorch.FiniteStateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.FiniteStateMachine
{
    public class Test : MonoBehaviour
    {

        public FiniteStateMachine fsm;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //fsm._currentHealth++;
            Debug.Log("Hey FSM, which is your actual current health?:" + fsm.GetCurrentHealth);
            fsm.SetState = States.MOVING_RIGHT;
        }
    }
}

