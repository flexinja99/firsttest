using System.Collections;               // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                                        // 단일 네임스페이스에서 모든 형식을 가져옵니다.



using System.Collections.Generic;             //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                                                             //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.
using UnityEngine;                           // using UnityEngine: 유니티 엔진을 사용한다는뜻
using UnityEngine.UI;                        // using UnityEngine.UI:  유니티 엔진 ui를 사용한다는뜻
public class HitTypePopText : MonoBehaviour     // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public static HitTypePopText instance;   // instance : 인스턴스화 ,이미 만들어진 게임 오브젝트를 필요할때마다 실시간으로 만드는것
    [SerializeField] private Color _colorCool;  // [SerializeField] : 스크립트 직렬화 직렬화는 데이터 구조나 오브젝트 상태를 Unity 에디터가 저장하고 나중에 재구성할 수 있는 포맷으로 자동으로 변환하는 프로세스를 말하는것.
    [SerializeField] private Color _colorGreat;  // Color : 스크립트를 통한 오브젝트 색상.컬러 변경
    [SerializeField] private Color _colorGood;
    [SerializeField] private Color _colorMiss;
    [SerializeField] private Color _colorBad;
    [SerializeField] private float _fadingTime = 0.1f; 
    [SerializeField] Text _text;                   // Text : ??
    private Coroutine _coroutine;                  // Corutine : 코루틴은 실행을 일시 중지하고 Unity에 제어 권한을 반환한 후 다음 프레임에서 중단했던 위치에서 계속할 수 있는 함수와 같음.
    private bool _isFading;
    private HitType _hitType;                    // hitType : 히트가 발생될 타입
    public HitType hitType
    {
        set
        {
            if (_isFading)
                StopCoroutine(_coroutine);             // StopCoroutine : 코루틴 중단
            RefreshText(value);                        //  Refresh : (새로고침)를 위한 UI
            _coroutine = StartCoroutine(E_Fading());   // value : 특정값만 가진 함수, 숫자 매기는 값
            _hitType = value;
        }
    }

    private void RefreshText(HitType hitType)
    {
        switch (hitType)    //switch :switch(스위치)문은 조건이 여러 경우(case)의 값을 가질 수 있고 각 값별로 처리할 코드를 만들 수 있다.
                                    //해당 케이스를 처리한 후에 switch문을 빠져나가기 위해서 break 키워드를 사용한다.
        {
            case HitType.Bad:        //case : 실행문
                _text.text = "BAD";
                _text.color = _colorBad;
                break;
            case HitType.Miss:
                _text.text = "MISS";
                _text.color = _colorMiss;
                break;
            case HitType.Good:
                _text.text = "Good";
                _text.color = _colorGood;
                break;
            case HitType.Great:
                _text.text = "Great";
                _text.color = _colorGreat;
                break;
            case HitType.Cool:
                _text.text = "Cool";
                _text.color = _colorCool;
                break;
            default:
                break;
        }
    }
    IEnumerator E_Fading()    // IEnumerator : 열거자 , 작업을 분활하여 수행하는 함수 , 함수 내부에 실행을 중지하고, 다음 프레임에서 실행을 재개할 수 있는 yield return 구문을 사용한다
    {
        _isFading = true;                     // ture, flase : 관계연산자가 참이면 true, 거짓이면 false를 반환 해야한다
        while (_text.color.a > 0)
        {
            _text.color = new Color(_text.color.r,    // new 키워드 :만든다 라는뜻
                                    _text.color.g,
                                    _text.color.b,
                                    _text.color.a - (1.0f * _fadingTime * Time.deltaTime));   //Time.deltaTime : 1초에 출력, 만들어낼 수 있는 프레임 횟수를 뜻한다.
        
            yield return null;  // yield return null : yield?return?null은 자주 사용하는 함수인?Update()가 끝나면 그때?yield?return?null구문의 밑의 부분이 실행됩니다
        
        }
        _isFading = false;
        _coroutine = null; // null :레퍼런스 변수가 오브젝트를 참조하지 않는 경우 null로 처리된다.
    }

    private void Awake()
    {
        instance = this; 
    }
}
