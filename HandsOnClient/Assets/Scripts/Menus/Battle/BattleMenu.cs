using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour
{
    public GameObject difficultySelect;
    public GameObject mainBattle;
    public GameObject result;

    public MainBattle mainBattleScript;

    public Result resultScript;

    private void DeactivateAll()
    {
        difficultySelect.SetActive(false);
        mainBattle.SetActive(false);
        result.SetActive(false);
    }

    public void Initialize()
    {
        DeactivateAll();
        difficultySelect.SetActive(true);
    }

    public void InitEasy()
    {
        DeactivateAll();
        mainBattleScript.Initialize(Difficulty.Easy);
        mainBattle.SetActive(true);
    }

    public void InitNormal()
    {
        DeactivateAll();
        mainBattleScript.Initialize(Difficulty.Normal);
        mainBattle.SetActive(true);
    }

    public void InitHard()
    {
        DeactivateAll();
        mainBattleScript.Initialize(Difficulty.Hard);
        mainBattle.SetActive(true);
    }

    public void ShowResult(bool isWin)
    {
        DeactivateAll();
        resultScript.Initialize(isWin);
        result.SetActive(true);
    }
}
