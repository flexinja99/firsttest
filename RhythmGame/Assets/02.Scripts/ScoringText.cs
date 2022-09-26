using System.Collections;// using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                         // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic;//   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                 //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.

using UnityEngine; // using UnityEngine: 유니티 엔진을 사용한다는뜻

using UnityEngine.UI;  // using UnityEngine.UI:  유니티 엔진 ui를 사용한다는뜻
public class ScoringText : MonoBehaviour // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public static ScoringText instance; // instance : 이미 만들어진 게임 오브젝트를 필요할 때마다 실시간으로 만든다는 의미입니다.
    private int _score;
    public int score
    {
        set //set: set 접근자에 대한 코드 블록은 속성에 새로운 값을 할당시킬 때 실행.
        {
            if (_isScoring)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(E_Scoring(_score, value));
            _score = value;
        }
        get    //get : get 접근자에 대한 코드 블록은 속성을 읽을 때 실행(호출 시 실행).
        {
            return _score;  //return : 반환
        }
    }

    [SerializeField] private Text _text;             // [SerializeField] : 스크립트 직렬화 직렬화는 데이터 구조나 오브젝트 상태를 Unity 에디터가 저장하고 나중에 재구성할 수 있는 포맷으로 자동으로 변환하는 프로세스를 말하는것.
    [SerializeField] private float _scoringTime = 0.1f; 
    private Coroutine _coroutine = null; 
    private bool _isScoring = false;

    IEnumerator E_Scoring(int before, int after)        //int before : ?
    {
        _isScoring = true;
        int delta = (int)((after - before) / _scoringTime);
        while (before < after)
        {
            before += (int)(delta * Time.deltaTime);
            if (before > after)
                before = after;
            _text.text = before.ToString();
            yield return null;
        }
        _isScoring = false;      
        _coroutine = null;
    }

    private void Awake()  //Awake() : Awake 는 일반적으로 게임이 시작되기 전에, 모든 변수와 게임의 상태를 초기화 하기 위해서 호출된다
    {
        instance = this;
    }
}
