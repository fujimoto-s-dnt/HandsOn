using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    private const string BaseUrl = "http://localhost:8000/";

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

    public async UniTask<DefaultData> GetDefaultData()
    {
        var jsonString = (await UnityWebRequest.Get(BaseUrl + "master/getDefaultData/").SendWebRequest()).downloadHandler.text;
        return JsonUtility.FromJson<DefaultData>(jsonString);
    }

    public async UniTask<CharacterMaster> GetCharacterMaster()
    {
        var jsonString = (await UnityWebRequest.Get(BaseUrl + "master/getCharacterMaster/").SendWebRequest()).downloadHandler.text;
        return JsonUtility.FromJson<CharacterMaster>(jsonString);
    }

    public async UniTask<StageMaster> GetStageMaster()
    {
        var jsonString = (await UnityWebRequest.Get(BaseUrl + "master/getStageMaster/").SendWebRequest()).downloadHandler.text;
        return JsonUtility.FromJson<StageMaster>(jsonString);
    }

    public async UniTask<int> DrawGacha()
    {
        var rawValue = (await UnityWebRequest.Get(BaseUrl + "gacha/draw/").SendWebRequest()).downloadHandler.text;
        return int.Parse(rawValue);
    }
}
