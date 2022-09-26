using System.Collections;// using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                         // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic; //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                  //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.

using UnityEngine; // using UnityEngine: 유니티 엔진을 사용한다는뜻

public class NoteSpawner : MonoBehaviour // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public KeyCode keyCode;
    [SerializeField] private GameObject _notePrefab; // [SerializeField] : 스크립트 직렬화 직렬화는 데이터 구조나 오브젝트 상태를 Unity 에디터가 저장하고 나중에 재구성할 수 있는 포맷으로 자동으로 변환하는 프로세스를 말하는것.

    public Note SpawnNote() 
    {
        GameObject note = Instantiate(_notePrefab, transform.position, Quaternion.identity);
        note.transform.localScale = transform.lossyScale;
        return note.GetComponent<Note>();
    }
}
