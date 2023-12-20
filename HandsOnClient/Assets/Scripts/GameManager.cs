using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject titleObject;

    public GameObject menuObject;

    public GameObject selectObject;

    public GameObject battleObject;

    public GameObject gachaObject;

    private void Start()
    {
        DeactivateAll();
        titleObject.SetActive(true);
    }

    private void DeactivateAll()
    {
        titleObject.SetActive(false);
        menuObject.SetActive(false);
        selectObject.SetActive(false);
        battleObject.SetActive(false);
        gachaObject.SetActive(false);
    }

    public void ShowMenu()
    {
        DeactivateAll();
        menuObject.SetActive(true);
    }

    public void ShowSelect()
    {
        DeactivateAll();
        selectObject.SetActive(true);
    }

    public void ShowBattle()
    {
        DeactivateAll();
        battleObject.SetActive(true);
    }

    public void ShowGacha()
    {
        DeactivateAll();
        gachaObject.SetActive(true);
    }
}
