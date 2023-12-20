using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public enum Turn
{
    Player,
    Enemy
}

public class MainBattle : MonoBehaviour
{
    public DisplayField playerDisplay;
    public DisplayField enemyDisplay;

    private Character enemyCharacter = new Character();
    private int enemyCurrentHp;

    private Character playerCharacter = new Character();
    private int playerCurrentHp;

    public Text attackButtonText;
    public Turn currentTurn = Turn.Player;

    private const string BattleHPStringFormat = "HP : {0}/{1}";

    public BattleMenu battleMenuScript;

    private void CopyMasterData(Character playerMaster, Character enemyMaster)
    {
        enemyCharacter.id = enemyMaster.id;
        enemyCharacter.hp = enemyMaster.hp;
        enemyCharacter.name = enemyMaster.name;
        enemyCharacter.minDmg = enemyMaster.minDmg;
        enemyCharacter.maxDmg = enemyMaster.maxDmg;
        enemyCharacter.image = enemyMaster.image;
        enemyCurrentHp = enemyMaster.hp;

        playerCharacter.id = playerMaster.id;
        playerCharacter.hp = playerMaster.hp;
        playerCharacter.name = playerMaster.name;
        playerCharacter.minDmg = playerMaster.minDmg;
        playerCharacter.maxDmg = playerMaster.maxDmg;
        playerCharacter.image = playerMaster.image;
        playerCurrentHp = playerMaster.hp;
    }

    public void Initialize(Difficulty diff)
    {
        var playerId = PlayerManager.instance.GetCurrentCharacter();
        var enemyId = 0;
        switch (diff)
        {
            case Difficulty.Easy:
                enemyId = MasterManager.instance.stageMaster.easyEnemyId;
                break;
            case Difficulty.Normal:
                enemyId = MasterManager.instance.stageMaster.normalEnemyId;
                break;
            case Difficulty.Hard:
                enemyId = MasterManager.instance.stageMaster.hardEnemyId;
                break;
        }

        playerDisplay.Initialize(playerId);
        enemyDisplay.Initialize(enemyId);

        CopyMasterData(MasterManager.instance.characterMaster.GetById(playerId), MasterManager.instance.characterMaster.GetById(enemyId));
    }

    public void Attack()
    {
        if (currentTurn == Turn.Player)
        {
            enemyCurrentHp -= Random.Range(playerCharacter.minDmg, playerCharacter.maxDmg);
            enemyDisplay.characterHp.text = string.Format(BattleHPStringFormat, enemyCurrentHp, enemyCharacter.hp);
            if (enemyCurrentHp <= 0)
            {
                Debug.Log("勝ち");
                battleMenuScript.ShowResult(true);
            }
            attackButtonText.text = "なぐられる";
            currentTurn = Turn.Enemy;
        }
        else
        {
            playerCurrentHp -= Random.Range(enemyCharacter.minDmg, enemyCharacter.maxDmg);
            playerDisplay.characterHp.text = string.Format(BattleHPStringFormat, playerCurrentHp, playerCharacter.hp);
            if (playerCurrentHp <= 0)
            {
                Debug.Log("負け");
                battleMenuScript.ShowResult(false);
            }
            attackButtonText.text = "なぐる";
            currentTurn = Turn.Player;
        }
    }
}
