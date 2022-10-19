using System;

public class StateMoveOff<T> : StateBase<T> where T : Enum

{
    public StateMoveOff(StateMachineBase<T> stateMachineBase, T machineState) : base(stateMachineBase, machineState)
    {

    }
}
    
