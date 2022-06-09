using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemGetActiveCharacter : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        foreach (var character in battleSystem.allCharacterList)
        {
            if (character.isDead)
            {
                return;
            }
            if (!character.isReady)
            {
                return;
            }
            battleSystem.activeCharacter = character;

            for (var i = 0; i < battleSystem.skillButtons.Count; i++)
            {
                var localSkill = character.skills[i];
                battleSystem.skillButtons[i].skill = character.skills[i];
                battleSystem.skillButtons[i].skillText.text = character.skills[i].Name;
                battleSystem.skillButtons[i].button.onClick.AddListener(delegate         
                {
                    battleSystem.PlayerChooseTargetState.SetSkill(localSkill);
                    battleSystem.SetState(battleSystem.PlayerChooseTargetState);
                    
                });
            }
            break;
        }
        if (battleSystem.activeCharacter.isEnemy)
        {
            //choose skill as enemy;
        }
        else
        {
            battleSystem.SetState(battleSystem.AwaitingOrdersState);
        }
    }
}
