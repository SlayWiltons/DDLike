using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemGetActiveCharacter : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        var notReady = 0;
        foreach (var character in battleSystem.allCharactersList)
        {
            if (character.IsReady())
            {
                battleSystem.activeCharacter = character;
                battleSystem.activeCharacter.ShowActiveMarker(1);
                battleSystem.SetCharacterInfo(battleSystem.activeCharacter);
                Checking(battleSystem);
                break;
            }
            if (!character.IsReady())
            {
                notReady++;
                if (notReady == battleSystem.allCharactersList.Count)
                {
                    battleSystem.n++;
                    notReady = 0;
                    battleSystem.SetState(battleSystem.StartRoundState);
                }
            }
        }
    }

    private void Checking(BattleSystem battleSystem)
    {
        if (battleSystem.activeCharacter.IsEnemy())
        {
            foreach (var enemy in battleSystem.allHeroesList)
            {
                battleSystem.activeCharacter.enemiesList.Add(enemy);
            }
            battleSystem.ClearButtons();
            battleSystem.waitButton.interactable = false;
            battleSystem.SetState(battleSystem.EnemyChooseTargetState);
        }
        else
        {
            foreach (var enemy in battleSystem.allEnemiesList)
            {
                battleSystem.activeCharacter.enemiesList.Add(enemy);
            }
            for (var i = 0; i < battleSystem.activeCharacter.skillsList.Count; i++)
            {
                var localSkill = battleSystem.activeCharacter.skillsList[i];
                battleSystem.skillButtons[i].skill = battleSystem.activeCharacter.skillsList[i];
                battleSystem.skillButtons[i].skillText.text = battleSystem.activeCharacter.skillsList[i].Name;
                battleSystem.skillButtons[i].button.onClick.RemoveAllListeners();
                battleSystem.skillButtons[i].button.interactable = true;
                battleSystem.skillButtons[i].button.onClick.AddListener(delegate
                {
                    battleSystem.PlayerChooseTargetState.SetSkill(localSkill);
                    battleSystem.SetState(battleSystem.PlayerChooseTargetState);
                });
            }
            battleSystem.waitButton.interactable = true;
            if (battleSystem.activeCharacter.skillsList.Count != battleSystem.skillButtons.Count)
            {
                for (var i = battleSystem.activeCharacter.skillsList.Count; i < battleSystem.skillButtons.Count; i++)
                {
                    battleSystem.skillButtons[i].skillText.text = "";
                    battleSystem.skillButtons[i].button.interactable = false;
                }
            }
        }
    }
}
