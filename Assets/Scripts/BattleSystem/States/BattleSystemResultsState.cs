using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemResultsState : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        var deads = new List<Hero>();
        foreach (var character in battleSystem.allCharactersList)
        {
            if (character.IsDead())
            {
                deads.Add(character);
            }
        }
        foreach (var dead in deads)
        {
            foreach (var character in battleSystem.allCharactersList)
            {
                if (character == dead)
                {
                    battleSystem.allCharactersList.Remove(character);
                    break;
                }
            }
        }
        if (!isAllDead(battleSystem.allEnemiesList) && !isAllDead(battleSystem.allHeroesList))
        {
            battleSystem.SetState(battleSystem.GetActiveCharacterState);
        }
        if (isAllDead(battleSystem.allEnemiesList))
        {
            battleSystem.endMenu.ShowEndPanel("You win!!!");
            battleSystem.SetState(battleSystem.FinalState);
        }
        if (isAllDead(battleSystem.allHeroesList))
        {
            battleSystem.endMenu.ShowEndPanel("You lose =(");
            battleSystem.SetState(battleSystem.FinalState);
        }
    }

    private bool isAllDead(List<Hero> listOfCharacter)
    {
        var chars = 0;
        foreach (var character in listOfCharacter)
        {
            if (!character.IsDead())
            {
                break;
            }
            if (character.IsDead())
            {
                chars++;
            }
        }
        if (chars == listOfCharacter.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
