using UnityEngine; // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                   // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using UnityEngine.Video; //using UnityEngine.Video : ����Ƽ �������� ������ �̿��Ѵٴ¶�
using UnityEditor; // using UnityEditor : ������ ��ũ��Ʈ,���� ����Ƽ���� �����ϴ� �޴��� �� �� ���Ǽ� �ִ� ����� Ȯ���Ͽ� ������ �� �ֽ��ϴ�.
public class NotesMaker : MonoBehaviour // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
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

    [SerializeField] private VideoPlayer _videoPlayer; // [SerializeField] : ��ũ��Ʈ ����ȭ ����ȭ�� ������ ������ ������Ʈ ���¸� Unity �����Ͱ� �����ϰ� ���߿� �籸���� �� �ִ� �������� �ڵ����� ��ȯ�ϴ� ���μ����� ���ϴ°�.
    public bool isRecording  
    {
        get => _videoPlayer.isPlaying;  // = ���� �����ϰ� �ִٴ°�
    }

    public void OnRecordButtonClick()    // = ���ڵ� ��ư�� ų��
    {
        _songData = new SongData();
        _songData.videoName = _videoPlayer.clip.name;        
        _videoPlayer.Play();
    }

    public void OnStopRecordButtonClick()     // = ���ڵ��ư�� ����
    {
        SaveSongData();     //SaveSongData() : �뷡 ������ ����
        _videoPlayer.Stop();
    }

    private void Update()
    {
        if (isRecording)     
            Recording();
    }

    private void Recording()               
    {
        foreach (KeyCode keyCode in _keyCodes) //Foreach :foreach���� ������ �迭�� ��Ƽ� �迭�� ��� �������� �ݺ������ִ� �ݺ����Դϴ�.

        {
            if (Input.GetKeyDown(keyCode))
                CreateNoteData(keyCode);
        }
    }

    private void CreateNoteData(KeyCode keyCode)
    {
        float roundedTime = (float)System.Math.Round(_videoPlayer.time, 2);         // roundedTime : ?
        NoteData noteData = new NoteData(keyCode, roundedTime, 1.0f);
        Debug.Log($"��Ʈ ������ ���� : {keyCode}, {roundedTime}");               //Debug.Log : ������ ���캸������ �ܼ�â�� ������� �Լ�
        _songData.notes.Add(noteData);
    }

    private void SaveSongData()
    {
        string dir = EditorUtility.SaveFilePanel("������ ���� �Է��ϼ���",       
                                                 "",
                                                 _songData.videoName,
                                                 "json");        
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));      // JsonUtility : jason �����͸� �ٷ�� ���ؼ� ����Ѵ�
                                                                              // WriteAllText: �� ������ ����� ������ ���ڿ��� ���Ͽ� �� ���� ������ �ݽ��ϴ�. ��� ������ �̹� ������ ����ϴ�.
    }
}
