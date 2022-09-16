using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using Unity.VisualScripting.FullSerializer;

public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _upgradeCostText;
    [SerializeField] private Vector3 _offset = Vector3.up * 3.0f;
    
    private int _upgradeCost;   
    private bool _upgradeAllfordable => _upgradeCost <= Player.Instance.money;

    public void SetUp(Tower tower)
    {
        // Upgrade 버튼 세팅
        if (TowerAssets.instance.TryGetTower(towerName: $"{tower.info.type}{tower.info.upgradeLevel + 1}",
                                             tower: out GameObject nextLevelTowerPrefab))
        {
            Tower nextLevelTower = nextLevelTowerPrefab.GetComponent<Tower>();
            _upgradeButton.gameObject.SetActive(true);
            _upgradeCost = nextLevelTower.info.buildPrice;
            _upgradeCostText.text = nextLevelTower.info.buildPrice.ToString();
            RefeshUpgradeCostTextColor();



            _upgradeButton.onClick.RemoveAllListeners();
            _upgradeButton.onClick.AddListener(() =>
            {
                if (_upgradeAllfordable)
                {
                    Upgrade(tower, nextLevelTower);
                    SetUp(nextLevelTower);
                }
              
            });

            
           
            _upgradeCost = nextLevelTower.info.buildPrice;
            _upgradeCostText.text = nextLevelTower.info.buildPrice.ToString();
            RefeshUpgradeCostTextColor();
        }
        else
        {
            _upgradeButton.gameObject.SetActive(false);
        }

        //Sell 버튼 세팅
        _sellButton.onClick.AddListener(() =>
        {
            Player.Instance.money += tower.info.sellPrice;
            tower.node.Clear();
            gameObject.SetActive(false);
        });

        gameObject.SetActive(true);
        transform.position = tower.transform.position + _offset;
    }

    public void Clear()
    {
        _upgradeCost = -1;
    }

    public void Upgrade(Tower before, Tower after)
    {
        if (before == null)
            return;

        Node node = before.node;
        node.Clear();
        node.TryBuildTowerHere($"{after.info.type}{after.info.upgradeLevel}");


    }

    public void Sell()
    {

    }

    private void Awake()
    {
        instance = this;
    }

    private void  Start()
    {
        Player.Instance.OnMoneyChanged += RefeshUpgradeCostTextColor;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Clear();
    }

    private void RefeshUpgradeCostTextColor()
    {
        if (_upgradeAllfordable)
            _upgradeCostText.color = Color.red;
        else
            _upgradeCostText.color = Color.black;
    }
}
