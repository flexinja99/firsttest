using System.Collections;// using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                         // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic;//   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                 //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.

using UnityEngine; // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�

using UnityEngine.UI;  // using UnityEngine.UI:  ����Ƽ ���� ui�� ����Ѵٴ¶�
public class ScoringText : MonoBehaviour // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public static ScoringText instance; // instance : �̹� ������� ���� ������Ʈ�� �ʿ��� ������ �ǽð����� ����ٴ� �ǹ��Դϴ�.
    private int _score;
    public int score
    {
        set //set: set �����ڿ� ���� �ڵ� ����� �Ӽ��� ���ο� ���� �Ҵ��ų �� ����.
        {
            if (_isScoring)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(E_Scoring(_score, value));
            _score = value;
        }
        get    //get : get �����ڿ� ���� �ڵ� ����� �Ӽ��� ���� �� ����(ȣ�� �� ����).
        {
            return _score;  //return : ��ȯ
        }
    }

    [SerializeField] private Text _text;             // [SerializeField] : ��ũ��Ʈ ����ȭ ����ȭ�� ������ ������ ������Ʈ ���¸� Unity �����Ͱ� �����ϰ� ���߿� �籸���� �� �ִ� �������� �ڵ����� ��ȯ�ϴ� ���μ����� ���ϴ°�.
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

    private void Awake()  //Awake() : Awake �� �Ϲ������� ������ ���۵Ǳ� ����, ��� ������ ������ ���¸� �ʱ�ȭ �ϱ� ���ؼ� ȣ��ȴ�
    {
        instance = this;
    }
}
