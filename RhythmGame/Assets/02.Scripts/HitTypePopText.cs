using System.Collections;               // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                                        // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.



using System.Collections.Generic;             //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                                                             //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.
using UnityEngine;                           // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�
using UnityEngine.UI;                        // using UnityEngine.UI:  ����Ƽ ���� ui�� ����Ѵٴ¶�
public class HitTypePopText : MonoBehaviour     // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public static HitTypePopText instance;   // instance : �ν��Ͻ�ȭ ,�̹� ������� ���� ������Ʈ�� �ʿ��Ҷ����� �ǽð����� ����°�
    [SerializeField] private Color _colorCool;  // [SerializeField] : ��ũ��Ʈ ����ȭ ����ȭ�� ������ ������ ������Ʈ ���¸� Unity �����Ͱ� �����ϰ� ���߿� �籸���� �� �ִ� �������� �ڵ����� ��ȯ�ϴ� ���μ����� ���ϴ°�.
    [SerializeField] private Color _colorGreat;  // Color : ��ũ��Ʈ�� ���� ������Ʈ ����.�÷� ����
    [SerializeField] private Color _colorGood;
    [SerializeField] private Color _colorMiss;
    [SerializeField] private Color _colorBad;
    [SerializeField] private float _fadingTime = 0.1f; 
    [SerializeField] Text _text;                   // Text : ??
    private Coroutine _coroutine;                  // Corutine : �ڷ�ƾ�� ������ �Ͻ� �����ϰ� Unity�� ���� ������ ��ȯ�� �� ���� �����ӿ��� �ߴ��ߴ� ��ġ���� ����� �� �ִ� �Լ��� ����.
    private bool _isFading;
    private HitType _hitType;                    // hitType : ��Ʈ�� �߻��� Ÿ��
    public HitType hitType
    {
        set
        {
            if (_isFading)
                StopCoroutine(_coroutine);             // StopCoroutine : �ڷ�ƾ �ߴ�
            RefreshText(value);                        //  Refresh : (���ΰ�ħ)�� ���� UI
            _coroutine = StartCoroutine(E_Fading());   // value : Ư������ ���� �Լ�, ���� �ű�� ��
            _hitType = value;
        }
    }

    private void RefreshText(HitType hitType)
    {
        switch (hitType)    //switch :switch(����ġ)���� ������ ���� ���(case)�� ���� ���� �� �ְ� �� ������ ó���� �ڵ带 ���� �� �ִ�.
                                    //�ش� ���̽��� ó���� �Ŀ� switch���� ���������� ���ؼ� break Ű���带 ����Ѵ�.
        {
            case HitType.Bad:        //case : ���๮
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
    IEnumerator E_Fading()    // IEnumerator : ������ , �۾��� ��Ȱ�Ͽ� �����ϴ� �Լ� , �Լ� ���ο� ������ �����ϰ�, ���� �����ӿ��� ������ �簳�� �� �ִ� yield return ������ ����Ѵ�
    {
        _isFading = true;                     // ture, flase : ���迬���ڰ� ���̸� true, �����̸� false�� ��ȯ �ؾ��Ѵ�
        while (_text.color.a > 0)
        {
            _text.color = new Color(_text.color.r,    // new Ű���� :����� ��¶�
                                    _text.color.g,
                                    _text.color.b,
                                    _text.color.a - (1.0f * _fadingTime * Time.deltaTime));   //Time.deltaTime : 1�ʿ� ���, ���� �� �ִ� ������ Ƚ���� ���Ѵ�.
        
            yield return null;  // yield return null : yield?return?null�� ���� ����ϴ� �Լ���?Update()�� ������ �׶�?yield?return?null������ ���� �κ��� ����˴ϴ�
        
        }
        _isFading = false;
        _coroutine = null; // null :���۷��� ������ ������Ʈ�� �������� �ʴ� ��� null�� ó���ȴ�.
    }

    private void Awake()
    {
        instance = this; 
    }
}
