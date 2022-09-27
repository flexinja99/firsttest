using System.Collections;  // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                           // 단일 네임스페이스에서 모든 형식을 가져옵니다.
using System.Collections.Generic;    //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                     //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.
using UnityEngine;         // using UnityEngine: 유니티 엔진을 사용한다는뜻

public class Note : MonoBehaviour   // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public KeyCode keyCode;
    private Transform _tr;   //transform : 모든 게임오브젝트에 기본으로 장착되는 컴퍼넌트 (유니티)
    public float speed;         //speed : 유니티 애니메이션 속도 조절

    public void Hit(HitType hitType)
    {
        //Debug.Log($"note hit ! {keyCode}, {hitType}");
        HitTypePopText.instance.hitType = hitType;         
        switch (hitType)//switch :switch(스위치)문은 조건이 여러 경우(case)의 값을 가질 수 있고 각 값별로 처리할 코드를 만들 수 있다.
                        //해당 케이스를 처리한 후에 switch문을 빠져나가기 위해서 break 키워드를 사용한다.
        {
            case HitType.Bad:                      //case : 실행문
                ScoringText.instance.score += Constants.SCORE_BAD;
                break;
            case HitType.Miss:
                ScoringText.instance.score += Constants.SCORE_MISS;      
                break;
            case HitType.Good:
                ScoringText.instance.score += Constants.SCORE_GOOD;
                break;
            case HitType.Great:
                ScoringText.instance.score += Constants.SCORE_GREAT;
                break;
            case HitType.Cool:
                ScoringText.instance.score += Constants.SCORE_COOL;
                break;
            default:
                break;
        }
        Destroy(gameObject); //Destory(gameObject) : 게임오브젝트 제거
    }

    private void Awake()  // Awake 함수 : Awake는 게임이 시작하기 전에 변수나 게임 상태를 초기화하기 위해 사용된다,  Awake는 언제나 Start 함수보다 먼저 호출된다.
    {
        _tr = GetComponent<Transform>(); //GetComponent : 게임 오브젝트의 컴포넌트를 가져오는 함수
    }
    private void FixedUpdate()  // FixedUpdate : 물리 효과가 적용된(Rigidbody) 오브젝트를 조정할 때 사용된다.
    {
        Move(); // Move : 오브젝트 이동
    }

    private void Move()
    { 
        _tr.Translate(Vector2.down * speed * NotesManager.noteSpeedScale * Time.fixedDeltaTime);
        // Vector 2 : Vector2 구조체는 2차원 평면 공간에 속하는 벡터로 X축의 좌표를 표시하기 위한 x 변수와, Y축의 값을 표시하기 위한 y 변수를 가진다.
        // Translate : 물체의 위치값을 기반으로 작동한다는 의미

    }
}
