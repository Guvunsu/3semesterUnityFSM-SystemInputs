using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//we have to retrieve the API of the Input System
using UnityEngine.InputSystem;

namespace SotomaYorch.FiniteStateMachine
{
    #region Enums

    public enum States
    {
        //IDLE
        IDLE_UP,
        IDLE_DOWN,
        IDLE_LEFT,
        IDLE_RIGHT,
        //MOVING
        MOVING_UP,
        MOVING_DOWN,
        MOVING_LEFT,
        MOVING_RIGHT
    }

    public enum PlaybleCharacterType
    {
        AVATAR,
        NPC
    }

    #endregion

    public class FiniteStateMachine : MonoBehaviour
    {
        #region Knobs

        //delcartation of the variable
        public States state;
        public PlaybleCharacterType characterType;
        //subscribers for two different input events
        public InputActionReference movementActionReference;
        public InputActionReference attackActionReference;

        #endregion

        #region RuntimeVariables

        protected int _currentHealth;

        #endregion

        #region UnityMethods

        private void Start()
        {
            state = States.IDLE_DOWN;
            //subscription moment for the event
            movementActionReference.action.performed += HandleMovement;
            //GetButtonDown
            attackActionReference.action.performed += HandleAttack;
            //GetButtonUp
            attackActionReference.action.canceled += HandleFinishAttack;
            //Invoke("IdleState", 3.0f);
        }

        //when:
        //die
        //pause
        //cinematic
        //talking to a NPC
        //Paralyzed status effect
        //Froxen status effect
        //Asleep status effect
        public void SuspendInput()
        {
            //desuscribe for the event
            movementActionReference.action.performed -= HandleMovement;
            attackActionReference.action.performed -= HandleAttack;
            attackActionReference.action.canceled -= HandleFinishAttack;
        }

        private void Update()
        {
            //Gettear la variable
            if (IsInIdleState)
            {
                Debug.Log(":D");
            }
            Debug.Log("Current health is " + _currentHealth);
            Debug.Log("Current health is " + GetCurrentHealth);

            //Setterar la variable

            Debug.Log(gameObject.name + " FiniteStateMachine - Update(): Is in any IDLE state " + IsInIdleState);

            Debug.Log(gameObject.name + " Finite State Machine - Update() - I'm in the " + state.ToString() + " state ;D");
            switch (state)
            {
                case States.IDLE_UP:
                case States.IDLE_DOWN:
                case States.IDLE_RIGHT:
                case States.IDLE_LEFT:
                    IdleState();
                    break;
                case States.MOVING_UP:
                case States.MOVING_DOWN:
                case States.MOVING_RIGHT:
                case States.MOVING_LEFT:
                    MovingState();
                    break;
                    /*
                    case States.IDLE:
                        IdleState();
                        break;
                    case States.PATROLLING:
                        PatrollingState();
                        break;
                    case States.PERSECUTING:
                        PersecutingState();
                        break;
                    */
            }
        }

        #endregion

        #region FiniteStateMachineMethods

        protected void IdleState()
        {
            /*
            if (Input.GetKeyDown(KeyCode.W))
            {
                //ChangeState(States.PATROLLING);
                SetState = States.MOVING_UP;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //ChangeState(States.PERSECUTING);
                SetState = States.MOVING_DOWN;
            }
            */
        }

        protected void MovingState()
        {

        }

        protected void PatrollingState()
        {
            /*
            if (Input.GetKeyDown(KeyCode.I))
            {
                //ChangeState(States.IDLE);
            }
            */
        }

        protected void PersecutingState()
        {
            Invoke("ChangeToIdleState", 3.0f);
        }

        #endregion

        #region PublicMethods

        public void ChangeState(States value)
        {
            Debug.Log(gameObject.name + " Finite State Machine - ChangeState() - We will move to the " + value.ToString() + " state :o");
            state = value;
        }

        #endregion

        #region LocalMethods

        protected void ChangeToIdleState()
        {
            //ChangeState(States.IDLE);
        }



        private void OnTriggerEnter(Collider other)
        {
            /*
            if (
                (state == States.PERSECUTING ||
                state == States.PATROLLING)
                && other.gameObject.tag == "Death")
            {
                ChangeState(States.IDLE);
            }
            */
        }

        #endregion

        #region GettersAndSetters

        public int GetCurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            //set
            //{
            //    _currentHealth = value;
            //}
        }

        protected bool IsInIdleState
        {
            get
            {
                return (state == States.IDLE_UP
                    || state == States.IDLE_DOWN
                    || state == States.IDLE_LEFT
                    || state == States.IDLE_RIGHT);
            }
        }

        public States SetState
        {
            set
            {
                Debug.Log(gameObject.name + " Finite State Machine - " +
                    "SetState - We will move to the " + value.ToString() + " state :o");
                state = value;
            }
        }

        #endregion

        //Mehtods which will handle each input event
        #region InputEvents

        protected Vector2 _movementInputVector;

        protected void HandleMovement(InputAction.CallbackContext value)
        {
            _movementInputVector = value.ReadValue<Vector2>();
            Debug.Log(gameObject.name + " Finite State Machine - HandleMovement(): "
                + "movement vector: " + _movementInputVector);
        }

        //we recieve the event similar to GetButtonDown(), which means
        //we receive the very first moment of the input
        protected void HandleAttack(InputAction.CallbackContext value)
        {
            //first press
            Debug.Log(gameObject.name + " Finite State Machine - HandleAttack(): "
                + "Attack STARTED");
        }
    
        //GetButtonUp
        protected void HandleFinishAttack(InputAction.CallbackContext value)
        {
            //release
            Debug.Log(gameObject.name + " Finite State Machine - HandleFinishAttack(): "
                + "Attack FINISHED");
        }

        #endregion
    }
}