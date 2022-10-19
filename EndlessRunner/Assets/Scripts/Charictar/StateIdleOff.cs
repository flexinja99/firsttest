using System;

public class StateMove<T> : StateBase<T> where T : Enum
{
    public StateMove(StateMachineBase<T> stateMachineBase, T machineState) : base(stateMachineBase, machineState)
    {

    }
}
