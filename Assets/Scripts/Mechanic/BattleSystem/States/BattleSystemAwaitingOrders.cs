using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemAwaitingOrders : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        Debug.Log("Awaiting Orders State");
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            battleSystem.activeCharacter.SetAsNotReady();
            battleSystem.SetState(battleSystem.GetActiveCharacterState);
        }*/
    }
}
