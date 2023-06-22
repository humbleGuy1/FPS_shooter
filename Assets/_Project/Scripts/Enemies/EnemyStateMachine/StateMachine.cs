using UnityEngine;

namespace EnemyLogic.States
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State _currentState;

        public void SetState(State targerState)
        {
            _currentState?.Exit();
            _currentState = targerState;
            _currentState.Enter();
        }
        
    }
}

