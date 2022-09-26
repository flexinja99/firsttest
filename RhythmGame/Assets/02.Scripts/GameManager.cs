using System.Collections;  // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                           // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic; //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                  //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.

using UnityEngine;  // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�

// ���� ���� �ӽ� (FSM : Finite State Machine)

public class GameManager : MonoBehaviour  // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public enum State             //State : �ִϸ��̼� ����
    {
        Idle,
        WaitForSongSelected,
        StartGame,
        WaitForGameFinished,
        ShowScore
    }
    private State _state; 

    private void Update()      // Update : ����Ƽ���� ���� ���� ����ϴ��Լ�, �����Ӹ��� �ѹ��� ȣ��,�����ӿ� ���� ȣ��Ǳ⶧���� �ð��� ���������� �ʴ�.
    {
        WorkFlow();
    }

    private void WorkFlow() 
    {
        switch (_state) // Switch : switch(����ġ)���� ������ ���� ���(case)�� ���� ���� �� �ְ� �� ������ ó���� �ڵ带 ���� �� �ִ�.�ش� ���̽��� ó���� �Ŀ� switch���� ���������� ���ؼ� break Ű���带 ����Ѵ�.




        {
            case State.Idle:
                break;
            case State.WaitForSongSelected:
                break;
            case State.StartGame:
                break;
            case State.WaitForGameFinished:
                break;
            case State.ShowScore:
                break;
            default:
                break;
        }
    }
}
