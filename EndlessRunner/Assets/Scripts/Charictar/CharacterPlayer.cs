using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer :CharacterBase
{

    public enum StateMachine
    {
        Idle,
        Move,
        Jump,
        Fall,
        Slide,
        WallRun,
        Hurt,
        Die

    }
    private StateMachineBase<StateTypes> _machine;

    private void Awake()
    {
        
    }
}
