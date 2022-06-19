using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemStartRoundState : BattleSystemBaseState
{
    public override void StartingState(BattleSystem battleSystem)
    {
        battleSystem.StartCoroutine(ShowingRound(battleSystem));
    }

    public override void ProceedingState(BattleSystem battleSystem)
    {
        
    }

    private IEnumerator ShowingRound(BattleSystem battleSystem)
    {
        Debug.Log("Round " + battleSystem.n);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Proceeding");
        battleSystem.SetState(battleSystem.GetActiveCharacterState);
    }
}
