using System.Collections.Generic;//   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                 //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.

[System.Serializable] //[System.Serializable] : [Serializable]는 클래스 또는 구조체를 직렬화 할수 있음을 나타낸다.
public class SongData
{
    public string videoName;
    public List<NoteData> notes;

    public SongData()
    {
        notes = new List<NoteData>();   //List : 리스트는 배열과 유사한 역할을 한다. List<자료형> 변수명 형태로 선언하며, 객체이므로 new연산자를 꼭 써줘야한다.
    }
}
