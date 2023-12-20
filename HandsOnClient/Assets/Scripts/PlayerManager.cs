using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

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

    private List<int> currentCharacterList = new List<int>();

    private int currentCharacterId;

    async void Start()
    {
        var data = await NetworkManager.instance.GetDefaultData();
        currentCharacterList.Add(data.startingCardId);
        currentCharacterId = data.startingCardId;
    }

    public int GetCurrentCharacter() => currentCharacterId;

    public void SetCurrentCharacter(int id) => currentCharacterId = id;
}
