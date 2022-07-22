using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemFinalState : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        foreach (var character in battleSystem.allCharactersList)
        {
            character.HideOnBoard();
        }
    }
}
