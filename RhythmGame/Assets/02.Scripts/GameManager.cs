using System.Collections;  // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                           // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic; //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                  //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.

using UnityEngine;  // using UnityEngine: 유니티 엔진을 사용한다는뜻

// 유한 상태 머신 (FSM : Finite State Machine)

public class GameManager : MonoBehaviour  // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public enum State             //State : 애니메이션 상태
    {
        Idle,
        WaitForSongSelected,
        StartGame,
        WaitForGameFinished,
        ShowScore
    }
    private State _state; 

    private void Update()      // Update : 유니티에서 가장 자주 사용하는함수, 프레임마다 한번씩 호출,프레임에 따라 호출되기때문에 시간이 일정하지가 않다.
    {
        WorkFlow();
    }

    private void WorkFlow() 
    {
        switch (_state) // Switch : switch(스위치)문은 조건이 여러 경우(case)의 값을 가질 수 있고 각 값별로 처리할 코드를 만들 수 있다.해당 케이스를 처리한 후에 switch문을 빠져나가기 위해서 break 키워드를 사용한다.




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
