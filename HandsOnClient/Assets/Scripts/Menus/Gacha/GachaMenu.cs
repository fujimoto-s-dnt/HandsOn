using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaMenu : MonoBehaviour
{
    public Image characterImage;

    public Text characterName;

    public Text characterHp;

    public Text characterDmg;

    private Character tempCharacter = new Character();

    public void Initialize()
    {
        characterImage.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        characterHp.gameObject.SetActive(false);
        characterDmg.gameObject.SetActive(false);
    }

    private void CopyMasterData(Character master)
    {
        tempCharacter.id = master.id;
        tempCharacter.hp = master.hp;
        tempCharacter.name = master.name;
        tempCharacter.minDmg = master.minDmg;
        tempCharacter.maxDmg = master.maxDmg;
        tempCharacter.addHpOnLvUp = master.addHpOnLvUp;
        tempCharacter.addMinDmgOnLvUp = master.addMinDmgOnLvUp;
        tempCharacter.addMaxDmgOnLvUp = master.addMaxDmgOnLvUp;
        tempCharacter.image = master.image;
    }

    public void SetCharacterData(int id)
    {
        var character = MasterManager.instance.characterMaster.GetById(id);
        SetCharacterData(character);
    }

    private void SetCharacterData(Character character)
    {
        CopyMasterData(character);
        characterImage.sprite = Resources.Load<Sprite>(character.image);
        characterImage.gameObject.SetActive(true);
        characterName.text = character.name;
        characterName.gameObject.SetActive(true);
        characterHp.text = "HP : " + character.hp.ToString();
        characterHp.gameObject.SetActive(true);
        characterDmg.text = Consts.GetDamageRangeText(character.minDmg, character.maxDmg);
        characterDmg.gameObject.SetActive(true);
    }

    public async void DrawGacha()
    {
        var drawId = await NetworkManager.instance.DrawGacha();

        SetCharacterData(drawId);
    }
}
