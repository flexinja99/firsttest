

using System;

public class StateMachineBase<T> where T : Enum
{
    public T Current;

    private void InitStates()
    {
        Array Values = Enum.GetValues(typeof(T));
        foreach (T value in Values)
        {

        }
    }

}
