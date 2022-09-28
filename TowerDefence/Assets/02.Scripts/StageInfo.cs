using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo 
{
    public int lifeInit;
    public int moneyInit;
    public List<StageInfo> stagInfo;
}

[System.Serializable]
public class StageInfo
{
    public List<EnemySpawnData> enemySpawnData = new List<EnemySpawnData>();
}

[System.Serializable]
public class EnemySpawnData
{
    public GameObject prefab;
    public int num;
}