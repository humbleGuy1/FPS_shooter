using EnemyLogic.Animation;
using UnityEngine;

namespace EnemyLogic.States
{
    public abstract class State : MonoBehaviour, IState
    {
        [SerializeField] protected EnemyAnimator _enemyAnimator;
        
        public virtual void Enter() => enabled = true;

        public virtual void Exit() => enabled = false;
    }
}
