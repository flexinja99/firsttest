using UnityEngine; // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                   // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using UnityEngine.Video; //using UnityEngine.Video : 유니티 엔진에서 비디오를 이용한다는뜻
using UnityEditor; // using UnityEditor : 에디터 스크립트,기존 유니티에서 제공하는 메뉴에 좀 더 편의성 있는 기능을 확장하여 제작할 수 있습니다.
public class NotesMaker : MonoBehaviour // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스
{
    private SongData _songData;
    private KeyCode[] _keyCodes =
    {
        KeyCode.S,
        KeyCode.D,
        KeyCode.F,
        KeyCode.Space,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
    };

    [SerializeField] private VideoPlayer _videoPlayer; // [SerializeField] : 스크립트 직렬화 직렬화는 데이터 구조나 오브젝트 상태를 Unity 에디터가 저장하고 나중에 재구성할 수 있는 포맷으로 자동으로 변환하는 프로세스를 말하는것.
    public bool isRecording  
    {
        get => _videoPlayer.isPlaying;  // = 비디오 실행하고 있다는것
    }

    public void OnRecordButtonClick()    // = 레코드 버튼을 킬때
    {
        _songData = new SongData();
        _songData.videoName = _videoPlayer.clip.name;        
        _videoPlayer.Play();
    }

    public void OnStopRecordButtonClick()     // = 레코드버튼을 끌때
    {
        SaveSongData();     //SaveSongData() : 노래 데이터 저장
        _videoPlayer.Stop();
    }

    private void Update()
    {
        if (isRecording)     
            Recording();
    }

    private void Recording()               
    {
        foreach (KeyCode keyCode in _keyCodes) //Foreach :foreach문은 변수를 배열에 담아서 배열에 담긴 변수들을 반복시켜주는 반복문입니다.

        {
            if (Input.GetKeyDown(keyCode))
                CreateNoteData(keyCode);
        }
    }

    private void CreateNoteData(KeyCode keyCode)
    {
        float roundedTime = (float)System.Math.Round(_videoPlayer.time, 2);         // roundedTime : ?
        NoteData noteData = new NoteData(keyCode, roundedTime, 1.0f);
        Debug.Log($"노트 데이터 생성 : {keyCode}, {roundedTime}");               //Debug.Log : 오류를 살펴보기위해 콘솔창에 띄워놓는 함수
        _songData.notes.Add(noteData);
    }

    private void SaveSongData()
    {
        string dir = EditorUtility.SaveFilePanel("저장할 곳을 입력하세여",       
                                                 "",
                                                 _songData.videoName,
                                                 "json");        
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));      // JsonUtility : jason 데이터를 다루기 위해서 사용한다
                                                                              // WriteAllText: 새 파일을 만들고 지정된 문자열을 파일에 쓴 다음 파일을 닫습니다. 대상 파일이 이미 있으면 덮어씁니다.
    }
}
