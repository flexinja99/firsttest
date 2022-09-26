using System.Collections;  // using : using 지시문을 사용하면 네임스페이스에 정의된 형식을 해당 형식의 정규화된 네임스페이스를 지정하지 않고도 사용할 수 있습니다,
                           // 단일 네임스페이스에서 모든 형식을 가져옵니다.

using System.Collections.Generic;  //   using System.Collections : 제네릭 컬렉션은 데이터 형식을 일반화하여 사용하기 때문에 컬렉션에 비해 성능의 문제가 적습니다.
                                   //제네릭 컬렉션은 List<T>, Dictionary<T> , Queue<T>, Stack<T> 등의 클래스가 있습니다.

using UnityEngine; // using UnityEngine: 유니티 엔진을 사용한다는뜻
using UnityEngine.Video; //using UnityEngine.Video : 유니티 엔진에서 비디오를 이용한다는뜻
public class SongSelector : MonoBehaviour  // MonoBehaviour: 유니티에서 생성하는 모든 스크립트가 상속받는 기본 클래스

{
#region 싱글톤
    public static SongSelector instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }
#endregion

    public VideoClip clip { get; private set; } 
    public SongData songData { get; private set; } 
    public bool isDataLoaded { get; private set; } 
    public void LoadSongData(string clipName)
    {
        bool isOK = true;  //bool isOk : ?
        try
        {
            clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");                      //try : 오류가 발생하는 구문을 포함 시켜준다
            TextAsset songDataText = Resources.Load<TextAsset>($"SongsData/{clipName}");    // Resources.Load : Resource 폴더는 유니티가 특별한 목적으로 예약한 폴더 중 하나로 해당 폴더에 에셋을 위치시키면 load함수를 사용하여 불러오기할수있다.
            songData = JsonUtility.FromJson<SongData>(songDataText.ToString());
        }
        catch                                                                               //Catch : 오류가 발생했을때 실행 시킬 구문
        {
            isOK = false;
        }

        isDataLoaded = isOK;
        if (isDataLoaded)
        {
            Debug.Log($"SongData Loaded : {clipName}"); // Debug.Log : 오류를 살피기위하여 콘솔창에 띄워놓는 함수
        }
    }
}
