using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemInitState : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        ShuffleCharacters(battleSystem);
        battleSystem.SetState(battleSystem.StartRoundState);
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        
    }

    private void ShuffleCharacters(BattleSystem battleSystem)
    {
        battleSystem.allCharactersList.AddRange(battleSystem.allEnemiesList);
        battleSystem.allCharactersList.AddRange(battleSystem.allHeroesList);
        for (var i = 0; i < battleSystem.allCharactersList.Count; i++)
        {
            var character = battleSystem.allCharactersList[i];
            var rand = Random.Range(i, battleSystem.allCharactersList.Count);
            battleSystem.allCharactersList[i] = battleSystem.allCharactersList[rand];
            battleSystem.allCharactersList[rand] = character;
        }
    }

    
}
