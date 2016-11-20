using UnityEngine;
using System.Collections;

public class GameStateMachine : MonoBehaviour
{

    public enum State : int
    {
        Initialize,
        Loading,
        Menu,
        Cinematic,
        Playing,
        Pause,
        Win,
        Lose

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
