using System.Collections;// using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                         // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic; //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                  //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.

using UnityEngine; // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�

public class NoteSpawner : MonoBehaviour // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public KeyCode keyCode;
    [SerializeField] private GameObject _notePrefab; // [SerializeField] : ��ũ��Ʈ ����ȭ ����ȭ�� ������ ������ ������Ʈ ���¸� Unity �����Ͱ� �����ϰ� ���߿� �籸���� �� �ִ� �������� �ڵ����� ��ȯ�ϴ� ���μ����� ���ϴ°�.

    public Note SpawnNote() 
    {
        GameObject note = Instantiate(_notePrefab, transform.position, Quaternion.identity);
        note.transform.localScale = transform.lossyScale;
        return note.GetComponent<Note>();
    }
}
