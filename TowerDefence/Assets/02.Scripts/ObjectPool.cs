
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<ObjectPool>("ObjectPool"));
            return _instance;
        }
    }

   private List<PoolElement> poolElements = new List<PoolElement>();    
    private List<GameObject> poolObjects = new List<GameObject>();
    private Dictionary<string, Queue<GameObject>> spawnedQueuePairs = new Dictionary<string, Queue<GameObject>>();

    //=============================
    //==public methods ===
    //===============================

    /// <summary>
    ///  필요한 객체와 갯수 발주
    /// </summary>
    /// <param name="poolElement"></param>

    public void AddPoolElement(PoolElement poolElement)
        => poolElements.Add(poolElement);


    public void InstantiateAllPoolElements()
    {
        foreach (PoolElement poolElement in poolElements)
        {
            spawnedQueuePairs.Add(poolElement.name, new Queue<GameObject>());
            for (int i =0; i < poolElement.num; i++)
            {
                InstantiatePoolElement(poolElement);
            }
        }

    }

    public GameObject Spawn(string tag, Vector3 spawnPoint)
    {
        if (spawnedQueuePairs.ContainsKey(name) == false)
            return null;

        if (spawnedQueuePairs[name].Count <= 0)
        {
            PoolElement poolElement = poolElements.Find(element => element.name == name);
            if(poolElement != null)
            {
                for (int i = 0; i < Math.Ceiling(poolElement.num)); i++)
                {
                    InstantiatePoolElement(poolElement);
                }
                
            }
        }

        GameObject go = spawnedQueuePairs[name].Dequeue();
        go.transform.position = spawnPoint;
        go.transform.SetParent(null);
        return go;
    }

    public void Return(GameObject obj)
    {
        if (spawnedQueuePairs.ContainsKey(obj.name) == false)
        {
            Debug.LogError($"[ObjectPool] :(obj.name) 는 왜가져왔어? 내가 빌려준적이 없는데?");
            return;
        }

        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        spawnedQueuePairs[obj.name].Enqueue(obj);
    }

    //================
    //=
    //====================

    private GameObject InstantiatePoolElement(PoolElement poolElement)
    {
        GameObject go = Instantiate(poolElement.prefab, transform);
        go.name = poolElement.name;
        spawnedQueuePairs[poolElement.name].Enqueue(go);
        go.SetActive(false);
        return go;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj">정렬하고 싶은 자식</param>
    private void RearrangeSiblings(GameObject obj)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == obj.name)
            {
                obj.transform.SetSiblingIndex(i);
                return;
            }
        }
        obj.transform.SetAsLastSibling();
    }
}



public class Player
{
    
    int Hp  // hp 프로퍼티
    {
        set
        {
            if (value <= 0)
            {
              
                Manager.Instance.Finish();
            }


        }
    }
}

public class Manager
{
    public static Manager Instance; 


    Manager()
    {
        Instance = this;
    }

    public void Finish()
    {
        
    }
}

