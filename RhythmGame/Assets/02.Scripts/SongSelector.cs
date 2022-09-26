using System.Collections;  // using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                           // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic;  //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                   //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.

using UnityEngine; // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�
using UnityEngine.Video; //using UnityEngine.Video : ����Ƽ �������� ������ �̿��Ѵٴ¶�
public class SongSelector : MonoBehaviour  // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����

{
#region �̱���
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
            clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");                      //try : ������ �߻��ϴ� ������ ���� �����ش�
            TextAsset songDataText = Resources.Load<TextAsset>($"SongsData/{clipName}");    // Resources.Load : Resource ������ ����Ƽ�� Ư���� �������� ������ ���� �� �ϳ��� �ش� ������ ������ ��ġ��Ű�� load�Լ��� ����Ͽ� �ҷ������Ҽ��ִ�.
            songData = JsonUtility.FromJson<SongData>(songDataText.ToString());
        }
        catch                                                                               //Catch : ������ �߻������� ���� ��ų ����
        {
            isOK = false;
        }

        isDataLoaded = isOK;
        if (isDataLoaded)
        {
            Debug.Log($"SongData Loaded : {clipName}"); // Debug.Log : ������ ���Ǳ����Ͽ� �ܼ�â�� ������� �Լ�
        }
    }
}
