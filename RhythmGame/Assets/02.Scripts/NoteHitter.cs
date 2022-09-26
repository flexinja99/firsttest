using System.Collections;  // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                           // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic; //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                  //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.


using UnityEngine; // using UnityEngine: 유니티 엔진을 사용한다는뜻
using System.Linq; // using System.Linq :  데이터를 조회, 질의 하고, 조건에 맞는 데이터를 추출, 조작하는 명령어입니다.

public enum HitType    //Enumerations는 열거형이란 뜻으로 줄여서 enum이라고 쓴다,
                       //  Enum은 의미있는 문자열에 숫자을 할당해줘서 코드를 단순하게 해주고, 숫자형과 문자형이 상호호환 가능해지게 해줍니다.
{
    Bad,     //}
    Miss,        
    Good,          // HitType 종류들
    Great,
    Cool    // }
}
public class NoteHitter : MonoBehaviour     // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    [SerializeField] private KeyCode _keyCode;    // [SerializeField] : 스크립트 직렬화 직렬화는 데이터 구조나 오브젝트 상태를 Unity 에디터가 저장하고 나중에 재구성할 수 있는 포맷으로 자동으로 변환하는 프로세스를 말하는것.
    private SpriteRenderer _spriteRenderer;      // private: 모든곳에 접근이 가능하다  //  SpriteRenderer: 스프라이트 렌더러(Sprite Renderer) 컴포넌트는 스프라이트 를 렌더링하고 스프라이트가 2D 및 3D 프로젝트의 씬에 시각적으로 표시되는 방식을 제어합니다.
    [SerializeField] private Color _pressedColor;  // pressedColor : 사용자 색 지정
    private Color _originColor;    // originColor : ?

    private void Awake()     // Awake :  Awake는 게임이 시작하기 전에 변수나 게임 상태를 초기화하기 위해 사용된다,  Awake는 언제나 Start 함수보다 먼저 호출된다.
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //GetComponent : 게임 오브젝트의 컴포넌트를 가져오는 함수  //*  여기서는 스프라이트 렌더러를 가져오는 함수이다
        _originColor = _spriteRenderer.color;
    }

    private void Update()  // Update : 유니티에서 가장 자주 사용하는함수, 프레임마다 한번씩 호출,프레임에 따라 호출되기때문에 시간이 일정하지가 않다.
    {
        if (Input.GetKeyDown(_keyCode))    // if : 괄호 안의 내용이 true(참)이면 중괄호 { } 안의 코드를 실행한다. false(거짓) 이면 실행하지 않는다. 
                                           // GetKeyDown : 해당되는 키를 눌렀을때 true 를 반환해 줍니다.
                                           // Input.GetKeyDown(_keyCode) : Input.GetKeyDown(_keyCode) 를 사용한다면 keycode 키를 꾹 누르고 있더라도 한번작동한뒤 다시 누를때까지 작동되지 않습니다.
        {
            ChangeColor();
            TryHitNote();
        }   
        if (Input.GetKeyUp(_keyCode))     //GetKeyUp : 해당되는 키를 눌렀다 땠을때 true를 반환해 줍니다
                                          //Input.GetKeyUp(_keyCode) : Input.GetKeyUp(_keyCode)를 사용하면 keycode를 눌렀다 땔경우에 한번 발생합니다
        {
            RollBackColor();
        }   
    }

    private bool TryHitNote()     //bool :  논리값의 자료형입니다.

    {
        List<Collider2D> notes =
            Physics2D.OverlapBoxAll(transform.position,                        // OverlapBoxAll : 상자 영역에 속하는 모든 충돌체 목록을 가져옵니다.
                                    new Vector2(transform.lossyScale.x / 2,    // Vector 2 : Vector2 구조체는 2차원 평면 공간에 속하는 벡터로 X축의 좌표를 표시하기 위한 x 변수와, Y축의 값을 표시하기 위한 y 변수를 가진다
                                                Constants.HIT_JUDGE_RANGE_BAD), // lossyScale : 게임 오브젝트의 절때적인 크기를 나타낸다
                                    0).ToList();   // ToList : 변환 연산자
        if (notes.Count > 0)
        {
            notes.Sort((x, y) => x.transform.position.y.CompareTo(y.transform.position.y));      //CompareTo : 해당 값과 밸류를 비교하여 결과값을 리턴해줍니다.

            //notes.OrderBy(note => Mathf.Abs(transform.position.y - note.transform.position.y));
            float distance = Mathf.Abs(transform.position.y - notes[0].transform.position.y); // distance : 거리를 측정할수있는 함수 , // Mathf : 일반적인 수학 함수컬렉션,
            // Mathf.Abs : 절댓값을 반환할 수

            HitType hitType = HitType.Bad;
            if (distance < Constants.HIT_JUDGE_RANGE_COOL)   
                hitType = HitType.Cool;
            else if (distance < Constants.HIT_JUDGE_RANGE_GREAT)
                hitType = HitType.Great;
            else if (distance < Constants.HIT_JUDGE_RANGE_GOOD)
                hitType = HitType.Good;
            else if (distance < Constants.HIT_JUDGE_RANGE_MISS)
                hitType = HitType.Miss;

            notes[0].GetComponent<Note>().Hit(hitType);
            return true;
        }                       // ture, flase : 관계연산자가 참이면 true, 거짓이면 false를 반환 해야한다
        return false;
    }


    private void ChangeColor() =>                 // ChangeColor : 스크립트를 통한 오브젝트 색상.컬러 변경하는 방법
        _spriteRenderer.color = _pressedColor;

    private void RollBackColor() =>
        _spriteRenderer.color = _originColor;

    private void OnDrawGizmosSelected()
    {
        // Bad 판정 범위
        Gizmos.color = Color.gray;                                        // Gizoms : 씬 뷰와 게임 뷰에는 모두 기즈모(Gizmos) 메뉴가 있습니다
        Gizmos.DrawWireCube(transform.position,                            
                            new Vector3(transform.lossyScale.x / 2,       // Vector3 :유니티에서는 3D 벡터의 값을 표현하기 위한 데이터타입은 Vector3 구조체이다. Vector3 데이터타입을 사용해서 3D 공간에서의 x, y, z 좌표를 가진 세 개의 원소로 표현해야 한다.
                                        Constants.HIT_JUDGE_RANGE_BAD,
                                        0));

        // Miss 판정 범위
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_MISS,
                                        0));

        // Good 판정 범위
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_GOOD,
                                        0));

        // Great 판정 범위
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_GREAT,
                                        0));

        // Cool 판정 범위
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_COOL,
                                        0));
    }
}
