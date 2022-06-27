using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemEnemyChooseTarget : BattleSystemBaseState
{
    private Skill chosenSkill;

    public override void StartingState(BattleSystem battleSystem)
    {
        int randSkill = Random.Range(0, battleSystem.activeCharacter.skillsList.Count);
        chosenSkill = battleSystem.activeCharacter.skillsList[randSkill];
        chosenSkill.EnemyChooseTarget(battleSystem);
    }
}
