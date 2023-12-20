using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviour
{
    public static MasterManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public CharacterMaster characterMaster { get; private set; }

    public StageMaster stageMaster { get; private set; }

    async void Start()
    {
        characterMaster = await NetworkManager.instance.GetCharacterMaster();
        stageMaster = await NetworkManager.instance.GetStageMaster();
    }
}
