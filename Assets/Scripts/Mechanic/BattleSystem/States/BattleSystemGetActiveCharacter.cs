using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemGetActiveCharacter : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        Debug.Log("GetActiveCharacterState");
        foreach (var character in battleSystem.allCharactersList)
        {
            if (character.IsDead())
            {
                return;
            }
            if (character.IsReady())
            {
                battleSystem.activeCharacter = character;
                break;
            }

        }

        if (battleSystem.activeCharacter.IsEnemy())
        {
            //choose skill as enemy;
            for (var i = 0; i < battleSystem.activeCharacter.skillsList.Count; i++)
            {
                battleSystem.skillButtons[i].skillText.text = "";
                battleSystem.skillButtons[i].button.interactable = false;
            }
            battleSystem.waitButton.interactable = false;
        }
        else
        {
            for (var i = 0; i < battleSystem.activeCharacter.skillsList.Count; i++)
            {
                var localSkill = battleSystem.activeCharacter.skillsList[i];
                battleSystem.skillButtons[i].skill = battleSystem.activeCharacter.skillsList[i];
                battleSystem.skillButtons[i].skillText.text = battleSystem.activeCharacter.skillsList[i].Name;
                battleSystem.skillButtons[i].button.interactable = true;

                battleSystem.skillButtons[i].button.onClick.AddListener(delegate
                {
                    battleSystem.PlayerChooseTargetState.SetSkill(localSkill);
                    battleSystem.SetState(battleSystem.PlayerChooseTargetState);
                });
                battleSystem.waitButton.interactable = true;
            }
            if (battleSystem.activeCharacter.skillsList.Count != battleSystem.skillButtons.Count)
            {
                for (var i = battleSystem.activeCharacter.skillsList.Count; i < battleSystem.skillButtons.Count; i++)
                {
                    battleSystem.skillButtons[i].skillText.text = "";
                    battleSystem.skillButtons[i].button.interactable = false;
                }
            }
            battleSystem.SetState(battleSystem.AwaitingOrdersState);
        }
    }
}
