using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Transform _start1;
    [SerializeField] private Transform _start2;
    [SerializeField] private Transform _start3;
    [SerializeField] private Button _BackToLobbyButton;
    [SerializeField] private Button _ReplayButton;
    [SerializeField] private Button _NextButton;

    public void SetUp(int level, float lifeRatio, System.Action value)
    {
        _level.text = level.ToString();

        
    }

    IEnumerator E_StarAnimation(float lifeRatio)
    {
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio>= 1.0f/ 3.0f)
            _start1.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio >= 2.0f / 3.0f)
            _start2.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (lifeRatio >= 3.0f / 3.0f)
            _start3.GetChild(0).gameObject.SetActive(true);
    }
}
