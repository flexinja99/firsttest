using System.Collections;  // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                           // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.
using System.Collections.Generic;    //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                     //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.
using UnityEngine;         // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�

public class Note : MonoBehaviour   // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public KeyCode keyCode;
    private Transform _tr;   //transform : ��� ���ӿ�����Ʈ�� �⺻���� �����Ǵ� ���۳�Ʈ (����Ƽ)
    public float speed;         //speed : ����Ƽ �ִϸ��̼� �ӵ� ����

    public void Hit(HitType hitType)
    {
        //Debug.Log($"note hit ! {keyCode}, {hitType}");
        HitTypePopText.instance.hitType = hitType;         
        switch (hitType)//switch :switch(����ġ)���� ������ ���� ���(case)�� ���� ���� �� �ְ� �� ������ ó���� �ڵ带 ���� �� �ִ�.
                        //�ش� ���̽��� ó���� �Ŀ� switch���� ���������� ���ؼ� break Ű���带 ����Ѵ�.
        {
            case HitType.Bad:                      //case : ���๮
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
        Destroy(gameObject); //Destory(gameObject) : ���ӿ�����Ʈ ����
    }

    private void Awake()  // Awake �Լ� : Awake�� ������ �����ϱ� ���� ������ ���� ���¸� �ʱ�ȭ�ϱ� ���� ���ȴ�,  Awake�� ������ Start �Լ����� ���� ȣ��ȴ�.
    {
        _tr = GetComponent<Transform>(); //GetComponent : ���� ������Ʈ�� ������Ʈ�� �������� �Լ�
    }
    private void FixedUpdate()  // FixedUpdate : ���� ȿ���� �����(Rigidbody) ������Ʈ�� ������ �� ���ȴ�.
    {
        Move(); // Move : ������Ʈ �̵�
    }

    private void Move()
    { 
        _tr.Translate(Vector2.down * speed * NotesManager.noteSpeedScale * Time.fixedDeltaTime);
        // Vector 2 : Vector2 ����ü�� 2���� ��� ������ ���ϴ� ���ͷ� X���� ��ǥ�� ǥ���ϱ� ���� x ������, Y���� ���� ǥ���ϱ� ���� y ������ ������.
        // Translate : ��ü�� ��ġ���� ������� �۵��Ѵٴ� �ǹ�

    }
}
