using UnityEngine;
using System.Collections.Generic;
using System;

public class CameraController : MonoBehaviour {

    public CameraFollowState follow = new CameraFollowState();
    
    protected List<State> _stateStack = new List<State>();

    public void AddState(State state)
    {
        if (!this._stateStack.Contains(state))
            this._stateStack.Add(state);
    }
}

public interface IState
{
    void Initialize();
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

    public abstract void Initialize();
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract bool Update();
}

[System.Serializable]
public class CameraFollowState : State
{
    public CameraFollowState()
    {
        Initialize();
    }

    public override void Initialize()
    {
      //nuthin'
    }

    public override void EnterState()
    {
        if (!this._isInitialized)
            Initialize();

        this._timer = this.duration;
    }

    public override bool Update()
    {
        this._timer -= Time.deltaTime;
        if (this._timer < 0)
            this._timer = 0;
        float normalizedTime = 1 - this._timer / this.duration;

        if (this._timer <= 0)
            if (!this.loop)
                return true;

        return false;
    }

    public override void ExitState()
    {

    }


}
