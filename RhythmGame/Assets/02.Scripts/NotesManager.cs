using System;
using System.Collections;// using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                         // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic;  //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                   //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.


using UnityEngine;  // using UnityEngine: 유니티 엔진을 사용한다는뜻
using UnityEngine.Video; //using UnityEngine.Video : 유니티 엔진에서 비디오를 이용한다는뜻
public class NotesManager : MonoBehaviour // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    public static float noteSpeedScale = 10f; //static : Dynamic의 반대로 알고 있다. 정적을 의미한다. 즉, 런타임 이전에 훨씬 이전에 수행되어 만들어진다는 뜻으로 알고 있다.
    private Dictionary<KeyCode, NoteSpawner> _spawners = new Dictionary<KeyCode, NoteSpawner>();
    private Queue<NoteData> _noteDataQueue = new Queue<NoteData>(); 

    [SerializeField] private Transform _spawnersPoint;   // 모든 게임 오브젝트에는 암시적으로 Transform 컴포넌트가 있으므로 자식 오브젝트는 부모의 Transform 컴포넌트를 통해 검색하여 가져올 수 있습니다.
    [SerializeField] private Transform _noteHittersPoint;
    
    public float noteFallingDistance      // float : 실수 타입
    {
        get => _spawnersPoint.position.y - _noteHittersPoint.position.y;    // get :get 접근자에 대한 코드 블록은 속성을 읽을 때 실행. (호출 시 실행)
    }

    public float noteFallingTime
    {
        get => noteFallingDistance / noteSpeedScale;
    }

    [SerializeField] private VideoPlayer _videoPlayer;

    public void StartSpawn()
    {
        if (_noteDataQueue.Count > 0)
        {            
            StartCoroutine(E_Spawning()); //StartCoroutine : 코루틴 시작
            Invoke("PlayVideoPlayer", noteFallingTime);  //Invoke : 시간 지연 기능
        }   
    }

    IEnumerator E_Spawning()  // IEnumerator : IEnumerator는 내부에서 IEnumerable을 사용하는 인터페이스로서 데이터의 검색 기능을 제공해 줍니다. 
                              //

    {
        float startTimeMark = Time.time; 
        while (_noteDataQueue.Count > 0)  // while : while 문은 요청한값만큼 무한으로 반복한다
        {
            for (int i = 0; i < _noteDataQueue.Count; i++)      //for : for문은 정해진 값만큼 값을 더해나가면서처리를 해주는 반복문입니다. //int : 정수타입

            {
                if (_noteDataQueue.Peek().time < (Time.time - startTimeMark))    // peek : 개체를 제거하지 않고 반환합니다.
                {
                    NoteData noteData = _noteDataQueue.Dequeue();

                    _spawners[noteData.keyCode].SpawnNote().speed *= noteData.speedScale;
                }
                else
                {
                    break;
                }
            }
            yield return null;     //yield return null: yield return null을 하게 되면 1프레임을 호출자에게 양보하란 뜻
        }
    }

    private void PlayVideoPlayer()
    {
        _videoPlayer.clip = SongSelector.instance.clip; //instance:인스턴스화란 유니티 기반으로 설명하면 메모리에 올려질 때 Awake()메소드가 호출될 때를 의미한다
        _videoPlayer.Play();
    }

    private void Awake()
    {
        StartCoroutine(E_Init()); 
    }

    IEnumerator E_Init()
    {
        NoteSpawner[] spawners = GameObject.Find("NoteSpawners").GetComponentsInChildren<NoteSpawner>();  //GetComponentsInChildren : 자식 객체들에게서 지정한 컴포넌트를 모두 추출한다,데이터가 여러 개라서 배열(Array)형태로 추출한다. 
        for (int i = 0; i < spawners.Length; i++)
        {
            _spawners.Add(spawners[i].keyCode, spawners[i]);
        }

        yield return new WaitUntil(() => SongSelector.instance != null &&             // WaitUntil: 코루틴에서 어떤 작업이 완료될 때까지 기다리는 방법이다, 마치 비동기 콜백 함수와 같은 기능을 수행한다.
                                         SongSelector.instance.isDataLoaded);   

        List<NoteData> notesData = SongSelector.instance.songData.notes;
        for (int i = 0; i < notesData.Count; i++)
        {
            float tmpSpeedScale = 0;
            if (notesData[i].speedScale > 0)
                tmpSpeedScale = notesData[i].speedScale;
            else
                tmpSpeedScale = 1;          

            float timeScaled = notesData[i].time * tmpSpeedScale;
            notesData[i].time = timeScaled;
        }

        notesData.Sort((x, y) => x.time.CompareTo(y.time));      //Sort : 정렬  
        for (int i = 0; i < notesData.Count; i++)             // CompareTo : 이 인스턴스를 지정된 String 개체와 비교하고 정렬 순서에서 이 인스턴스의 위치가 지정된 문자열보다 앞인지, 뒤인지 또는 동일한지를 나타냅니다.
        {
            _noteDataQueue.Enqueue(notesData[i]);
        }
    }
}
