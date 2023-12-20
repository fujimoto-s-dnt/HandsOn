using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayField : MonoBehaviour
{
    public Image characterImage;

    public Text characterHp;

    public Text characterDmg;

    private Character tempCharacter = new Character();

    public void Initialize(int characterId)
    {
        SetCharacterData(characterId);
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
        characterHp.text = "HP : " + character.hp.ToString();
        characterDmg.text = Consts.GetDamageRangeText(character.minDmg, character.maxDmg);
    }
}
