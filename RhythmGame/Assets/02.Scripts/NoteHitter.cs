using System.Collections;  // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                           // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic; //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                  //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.


using UnityEngine; // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�
using System.Linq; // using System.Linq :  �����͸� ��ȸ, ���� �ϰ�, ���ǿ� �´� �����͸� ����, �����ϴ� ��ɾ��Դϴ�.

public enum HitType    //Enumerations�� �������̶� ������ �ٿ��� enum�̶�� ����,
                       //  Enum�� �ǹ��ִ� ���ڿ��� ������ �Ҵ����༭ �ڵ带 �ܼ��ϰ� ���ְ�, �������� �������� ��ȣȣȯ ���������� ���ݴϴ�.
{
    Bad,     //}
    Miss,        
    Good,          // HitType ������
    Great,
    Cool    // }
}
public class NoteHitter : MonoBehaviour     // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    [SerializeField] private KeyCode _keyCode;    // [SerializeField] : ��ũ��Ʈ ����ȭ ����ȭ�� ������ ������ ������Ʈ ���¸� Unity �����Ͱ� �����ϰ� ���߿� �籸���� �� �ִ� �������� �ڵ����� ��ȯ�ϴ� ���μ����� ���ϴ°�.
    private SpriteRenderer _spriteRenderer;      // private: ������ ������ �����ϴ�  //  SpriteRenderer: ��������Ʈ ������(Sprite Renderer) ������Ʈ�� ��������Ʈ �� �������ϰ� ��������Ʈ�� 2D �� 3D ������Ʈ�� ���� �ð������� ǥ�õǴ� ����� �����մϴ�.
    [SerializeField] private Color _pressedColor;  // pressedColor : ����� �� ����
    private Color _originColor;    // originColor : ?

    private void Awake()     // Awake :  Awake�� ������ �����ϱ� ���� ������ ���� ���¸� �ʱ�ȭ�ϱ� ���� ���ȴ�,  Awake�� ������ Start �Լ����� ���� ȣ��ȴ�.
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //GetComponent : ���� ������Ʈ�� ������Ʈ�� �������� �Լ�  //*  ���⼭�� ��������Ʈ �������� �������� �Լ��̴�
        _originColor = _spriteRenderer.color;
    }

    private void Update()  // Update : ����Ƽ���� ���� ���� ����ϴ��Լ�, �����Ӹ��� �ѹ��� ȣ��,�����ӿ� ���� ȣ��Ǳ⶧���� �ð��� ���������� �ʴ�.
    {
        if (Input.GetKeyDown(_keyCode))    // if : ��ȣ ���� ������ true(��)�̸� �߰�ȣ { } ���� �ڵ带 �����Ѵ�. false(����) �̸� �������� �ʴ´�. 
                                           // GetKeyDown : �ش�Ǵ� Ű�� �������� true �� ��ȯ�� �ݴϴ�.
                                           // Input.GetKeyDown(_keyCode) : Input.GetKeyDown(_keyCode) �� ����Ѵٸ� keycode Ű�� �� ������ �ִ��� �ѹ��۵��ѵ� �ٽ� ���������� �۵����� �ʽ��ϴ�.
        {
            ChangeColor();
            TryHitNote();
        }   
        if (Input.GetKeyUp(_keyCode))     //GetKeyUp : �ش�Ǵ� Ű�� ������ ������ true�� ��ȯ�� �ݴϴ�
                                          //Input.GetKeyUp(_keyCode) : Input.GetKeyUp(_keyCode)�� ����ϸ� keycode�� ������ ����쿡 �ѹ� �߻��մϴ�
        {
            RollBackColor();
        }   
    }

    private bool TryHitNote()     //bool :  ������ �ڷ����Դϴ�.

    {
        List<Collider2D> notes =
            Physics2D.OverlapBoxAll(transform.position,                        // OverlapBoxAll : ���� ������ ���ϴ� ��� �浹ü ����� �����ɴϴ�.
                                    new Vector2(transform.lossyScale.x / 2,    // Vector 2 : Vector2 ����ü�� 2���� ��� ������ ���ϴ� ���ͷ� X���� ��ǥ�� ǥ���ϱ� ���� x ������, Y���� ���� ǥ���ϱ� ���� y ������ ������
                                                Constants.HIT_JUDGE_RANGE_BAD), // lossyScale : ���� ������Ʈ�� �������� ũ�⸦ ��Ÿ����
                                    0).ToList();   // ToList : ��ȯ ������
        if (notes.Count > 0)
        {
            notes.Sort((x, y) => x.transform.position.y.CompareTo(y.transform.position.y));      //CompareTo : �ش� ���� ����� ���Ͽ� ������� �������ݴϴ�.

            //notes.OrderBy(note => Mathf.Abs(transform.position.y - note.transform.position.y));
            float distance = Mathf.Abs(transform.position.y - notes[0].transform.position.y); // distance : �Ÿ��� �����Ҽ��ִ� �Լ� , // Mathf : �Ϲ����� ���� �Լ��÷���,
            // Mathf.Abs : ������ ��ȯ�� ��

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
        }                       // ture, flase : ���迬���ڰ� ���̸� true, �����̸� false�� ��ȯ �ؾ��Ѵ�
        return false;
    }


    private void ChangeColor() =>                 // ChangeColor : ��ũ��Ʈ�� ���� ������Ʈ ����.�÷� �����ϴ� ���
        _spriteRenderer.color = _pressedColor;

    private void RollBackColor() =>
        _spriteRenderer.color = _originColor;

    private void OnDrawGizmosSelected()
    {
        // Bad ���� ����
        Gizmos.color = Color.gray;                                        // Gizoms : �� ��� ���� �信�� ��� �����(Gizmos) �޴��� �ֽ��ϴ�
        Gizmos.DrawWireCube(transform.position,                            
                            new Vector3(transform.lossyScale.x / 2,       // Vector3 :����Ƽ������ 3D ������ ���� ǥ���ϱ� ���� ������Ÿ���� Vector3 ����ü�̴�. Vector3 ������Ÿ���� ����ؼ� 3D ���������� x, y, z ��ǥ�� ���� �� ���� ���ҷ� ǥ���ؾ� �Ѵ�.
                                        Constants.HIT_JUDGE_RANGE_BAD,
                                        0));

        // Miss ���� ����
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_MISS,
                                        0));

        // Good ���� ����
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_GOOD,
                                        0));

        // Great ���� ����
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_GREAT,
                                        0));

        // Cool ���� ����
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2,
                                        Constants.HIT_JUDGE_RANGE_COOL,
                                        0));
    }
}
