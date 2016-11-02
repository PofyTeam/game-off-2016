using UnityEngine;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    //public CameraFollowState followState = new CameraFollowState(1, true);
    public bool follow;
    protected List<State> _stateStack = new List<State>();

    void Start()
    {
        if (this.follow)
        {
       //     AddState(this.followState);
        }
    }

    public void AddState(State state)
    {
        if (!this._stateStack.Contains(state))
        {
            this._stateStack.Add(state);
            state.EnterState();
        }
    }

    public void StackState(State state)
    {
        this._stateStack.Add(state);
        state.EnterState();
    }

    public void RemoveState(State state)
    {
        this._stateStack.Remove(state);
        state.ExitState();
    }

    public bool HasState(State state)
    {
        return this._stateStack.Contains(state);
    }
}

public interface IState
{
    void Initialize(float duration, bool loop);
    void EnterState();
    bool Update();
    void ExitState();
}

public abstract class State : IState
{
    public float duration = 1;
    protected float _timer;

    protected bool _isInitialized;
    public bool loop;

    public abstract void Initialize(float duration, bool loop);
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract bool Update();
}

