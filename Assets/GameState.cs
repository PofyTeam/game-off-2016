namespace PofyTools
{
    using UnityEngine;
    using System.Collections;

    public abstract class GameState : IState
    {
        public GameStateMachine.State state;
        public UpdateDelegate onEnter;
        public UpdateDelegate onExit;

        public virtual void Enter()
        {
            if (this.onEnter != null)
                this.onEnter.Invoke();
        }

        public virtual void Exit()
        {
            if (this.onExit != null)
                this.onExit.Invoke();
        }
        public abstract void FixedUpdate();
        public abstract void LateUpdate();
        public abstract void Update();
    }

    public interface IState
    {
        void Enter();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void Exit();
    }

}