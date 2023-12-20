using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions.Must;
using Unity.VisualScripting;

public class SelectCharacterMenu : MonoBehaviour
{
    public Image characterImage;
    public Text characterName;
    public Text characterHp;
    public Text characterDmg;

    private int currentIndex;

    private Character tempCharacter = new Character();

    public void Initialize()
    {
        var currentCharacterId = PlayerManager.instance.GetCurrentCharacter();
        currentIndex = currentCharacterId;
        SetCharacterData(currentCharacterId);
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
        characterName.text = character.name;
        characterHp.text = "HP : " + character.hp.ToString();
        characterDmg.text = Consts.GetDamageRangeText(character.minDmg, character.maxDmg);
    }

    public void LeftButton()
    {
        var character = MasterManager.instance.characterMaster.GetById(currentIndex - 1);

        if (character == null)
        {
            Debug.Log("キャラいないぜ");
            return;
        }

        SetCharacterData(character.id);
        currentIndex = character.id;
    }

    public void RightButton()
    {
        var character = MasterManager.instance.characterMaster.GetById(currentIndex + 1);

        if (character == null)
        {
            Debug.Log("キャラいないぜ");
            return;
        }

        SetCharacterData(character.id);
        currentIndex = character.id;
    }

    public void PowerUpButton()
    {
        tempCharacter.hp += tempCharacter.addHpOnLvUp;
        tempCharacter.minDmg += tempCharacter.addMinDmgOnLvUp;
        tempCharacter.maxDmg += tempCharacter.addMaxDmgOnLvUp;

        SetCharacterData(tempCharacter);
    }

    public void SelectCharacter()
    {
        PlayerManager.instance.SetCurrentCharacter(tempCharacter.id);
    }
}
