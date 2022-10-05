using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    public enum States
    {
        Idle,
        SetUpLevel,
        PlayStartEvents,
        WaitForStartEvents,
        PlayStage,
        WaitForStageFinished,
        NextStage,
        LevelCompleted,
        LevelFailed,
        WaitForUser,
    }
    public States state;
    public LevelInfo levelInfo;
    public int currentStage;
    public int currentStageId;
    private Dictionary<int, bool> _stageFinishedPairs;
    private float _nextStageDelay = 0.5f;

    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private LevelCompletePanel _levelCompletePanelPrefab;
    [SerializeField] private LevelFailedPanel _levelFailedPanelPrefab;

    public void StartLevel()
    {
        if (state == States.Idle)
            state = States.SetUpLevel;
    }

    public void NextStage()
    {
        if (currentStage < levelInfo.stagesInfo.Count - 1 &&
            state == States.WaitForStageFinished)
            state = States.NextStage;
    }

    private void Pause(bool pause)
    {
        if (pause)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        instance = this;
        StartCoroutine(E_Init());
    }

    IEnumerator E_Init()
    {
        yield return new WaitUntil(() => Player.instance);
        Player.instance.SetUp(levelInfo.lifeInit,
                              levelInfo.moneyInit);

        _stageFinishedPairs = new Dictionary<int, bool>();

        for (int i = 0; i < levelInfo.stagesInfo.Count; i++)
            _stageFinishedPairs.Add(levelInfo.stagesInfo[i].id, false);

        _spawner.OnStageFinished += OnStageFinished;

        StartLevel();
    }

    private void Update()
    {
        switch (state)
        {
            case States.Idle:
                break;
            case States.SetUpLevel:
                {
                    Pathfinder.SetNodeMap();
                    Player.instance.OnLifeChanged += CheckLevelFailed;
                    state = States.PlayStartEvents;
                }
                break;
            case States.PlayStartEvents:
                {
                    state = States.WaitForStartEvents;
                }
                break;
            case States.WaitForStartEvents:
                {
                    state = States.PlayStage;
                }
                break;
            case States.PlayStage:
                {
                    _spawner.StartSpawn(levelInfo.stagesInfo[currentStage]);
                    currentStageId = levelInfo.stagesInfo[currentStage].id;
                    state = States.WaitForStageFinished;
                }
                break;
            case States.WaitForStageFinished:
                // nothing to do
                break;
            case States.NextStage:
                {
                    currentStage++;
                    state = States.PlayStage;
                }
                break;
            case States.LevelCompleted:
                {
                    Pause(true);
                    Instantiate(_levelCompletePanelPrefab).SetUp(levelInfo.level,
                                                                 (float)Player.instance.life / levelInfo.lifeInit,
                                                                 () => Pause(false));
                    state = States.WaitForUser;
                }
                break;
            case States.LevelFailed:
                {
                    Pause(true);
                    Instantiate(_levelFailedPanelPrefab).SetUp(levelInfo.level,
                                                               () => Pause(false));
                    state = States.WaitForUser;
                }
                break;
            case States.WaitForUser:
                // nothiong to do
                break;
            default:
                break;
        }
    }

    private void MoveNext()
    {
        if (state < States.WaitForUser)
            state++;
    }

    /// <summary>
    /// �������� ����?? ȣ��Ǵ� �ݹ�
    /// ȣ��ɶ����� ������ �������� ���� üũ
    /// </summary>
    /// <param name="stageId">�������� ���� �ν� ��ȣ</param>
    private void OnStageFinished(int stageId)
    {
        // stage id ��ȿ���� üũ
        if (_stageFinishedPairs.TryGetValue(stageId, out bool isFinished) &&
            isFinished == false)
        {
            _stageFinishedPairs[stageId] = true;

            // ���� ��������üũ
            if (IsLevelFinished())
            {
                OnLevelFinished();
            }
            // ���� �����⸦ ��ٸ��� ���������� �����Ÿ� ���� �������� ����
            else if (stageId == currentStageId)
            {
                _spawner.DestroyAllSkipButtons();
                Invoke("NextStage", _nextStageDelay);
            }
        }
    }

    private bool IsLevelFinished()
    {
        bool isFinished = true;
        foreach (var pair in _stageFinishedPairs)
        {
            if (pair.Value == false)
                isFinished = false;
        }
        return isFinished;
    }

    private void OnLevelFinished()
    {
        state = States.LevelCompleted;
    }

    private void CheckLevelFailed(int life)
    {
        if (life <= 0)
            state = States.LevelFailed;
    }


}
