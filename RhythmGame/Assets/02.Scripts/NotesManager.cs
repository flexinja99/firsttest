using System;
using System.Collections;// using : using ���ù��� ����ϸ� ���ӽ����̽��� ���ǵ� ������ �ش� ������ ����ȭ�� ���ӽ����̽��� �������� �ʰ� ����� �� �ֽ��ϴ�,
                         // ���� ���ӽ����̽����� ��� ������ �����ɴϴ�.

using System.Collections.Generic;  //   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                   //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.


using UnityEngine;  // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�
using UnityEngine.Video; //using UnityEngine.Video : ����Ƽ �������� ������ �̿��Ѵٴ¶�
public class NotesManager : MonoBehaviour // MonoBehaviour: ����Ƽ���� �����ϴ� ��� ��ũ��Ʈ�� ��ӹ޴� �⺻ Ŭ����
{
    public static float noteSpeedScale = 10f; //static : Dynamic�� �ݴ�� �˰� �ִ�. ������ �ǹ��Ѵ�. ��, ��Ÿ�� ������ �ξ� ������ ����Ǿ� ��������ٴ� ������ �˰� �ִ�.
    private Dictionary<KeyCode, NoteSpawner> _spawners = new Dictionary<KeyCode, NoteSpawner>();
    private Queue<NoteData> _noteDataQueue = new Queue<NoteData>(); 

    [SerializeField] private Transform _spawnersPoint;   // ��� ���� ������Ʈ���� �Ͻ������� Transform ������Ʈ�� �����Ƿ� �ڽ� ������Ʈ�� �θ��� Transform ������Ʈ�� ���� �˻��Ͽ� ������ �� �ֽ��ϴ�.
    [SerializeField] private Transform _noteHittersPoint;
    
    public float noteFallingDistance      // float : �Ǽ� Ÿ��
    {
        get => _spawnersPoint.position.y - _noteHittersPoint.position.y;    // get :get �����ڿ� ���� �ڵ� ����� �Ӽ��� ���� �� ����. (ȣ�� �� ����)
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
            StartCoroutine(E_Spawning()); //StartCoroutine : �ڷ�ƾ ����
            Invoke("PlayVideoPlayer", noteFallingTime);  //Invoke : �ð� ���� ���
        }   
    }

    IEnumerator E_Spawning()  // IEnumerator : IEnumerator�� ���ο��� IEnumerable�� ����ϴ� �������̽��μ� �������� �˻� ����� ������ �ݴϴ�. 
                              //

    {
        float startTimeMark = Time.time; 
        while (_noteDataQueue.Count > 0)  // while : while ���� ��û�Ѱ���ŭ �������� �ݺ��Ѵ�
        {
            for (int i = 0; i < _noteDataQueue.Count; i++)      //for : for���� ������ ����ŭ ���� ���س����鼭ó���� ���ִ� �ݺ����Դϴ�. //int : ����Ÿ��

            {
                if (_noteDataQueue.Peek().time < (Time.time - startTimeMark))    // peek : ��ü�� �������� �ʰ� ��ȯ�մϴ�.
                {
                    NoteData noteData = _noteDataQueue.Dequeue();

                    _spawners[noteData.keyCode].SpawnNote().speed *= noteData.speedScale;
                }
                else
                {
                    break;
                }
            }
            yield return null;     //yield return null: yield return null�� �ϰ� �Ǹ� 1�������� ȣ���ڿ��� �纸�϶� ��
        }
    }

    private void PlayVideoPlayer()
    {
        _videoPlayer.clip = SongSelector.instance.clip; //instance:�ν��Ͻ�ȭ�� ����Ƽ ������� �����ϸ� �޸𸮿� �÷��� �� Awake()�޼ҵ尡 ȣ��� ���� �ǹ��Ѵ�
        _videoPlayer.Play();
    }

    private void Awake()
    {
        StartCoroutine(E_Init()); 
    }

    IEnumerator E_Init()
    {
        NoteSpawner[] spawners = GameObject.Find("NoteSpawners").GetComponentsInChildren<NoteSpawner>();  //GetComponentsInChildren : �ڽ� ��ü�鿡�Լ� ������ ������Ʈ�� ��� �����Ѵ�,�����Ͱ� ���� ���� �迭(Array)���·� �����Ѵ�. 
        for (int i = 0; i < spawners.Length; i++)
        {
            _spawners.Add(spawners[i].keyCode, spawners[i]);
        }

        yield return new WaitUntil(() => SongSelector.instance != null &&             // WaitUntil: �ڷ�ƾ���� � �۾��� �Ϸ�� ������ ��ٸ��� ����̴�, ��ġ �񵿱� �ݹ� �Լ��� ���� ����� �����Ѵ�.
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

        notesData.Sort((x, y) => x.time.CompareTo(y.time));      //Sort : ����  
        for (int i = 0; i < notesData.Count; i++)             // CompareTo : �� �ν��Ͻ��� ������ String ��ü�� ���ϰ� ���� �������� �� �ν��Ͻ��� ��ġ�� ������ ���ڿ����� ������, ������ �Ǵ� ���������� ��Ÿ���ϴ�.
        {
            _noteDataQueue.Enqueue(notesData[i]);
        }
    }
}
