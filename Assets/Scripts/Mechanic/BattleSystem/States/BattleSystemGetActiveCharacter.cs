using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemGetActiveCharacter : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        foreach (var character in battleSystem.allCharactersList)
        {
            if (character.IsDead())
            {
                return;
            }
            if (!character.IsReady())
            {
                return;
            }
            battleSystem.activeCharacter = character;

            for (var i = 0; i < battleSystem.skillButtons.Count; i++)
            {
                var localSkill = character.skillsList[i];
                battleSystem.skillButtons[i].skill = character.skillsList[i];
                battleSystem.skillButtons[i].skillText.text = character.skillsList[i].Name;
                battleSystem.skillButtons[i].button.onClick.AddListener(delegate         
                {
                    battleSystem.PlayerChooseTargetState.SetSkill(localSkill);
                    battleSystem.SetState(battleSystem.PlayerChooseTargetState);
                    
                });
            }
            break;
        }
        if (battleSystem.activeCharacter.IsEnemy())
        {
            //choose skill as enemy;
        }
        else
        {
            battleSystem.SetState(battleSystem.AwaitingOrdersState);
        }
    }
}
