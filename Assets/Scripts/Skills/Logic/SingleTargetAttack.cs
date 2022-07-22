using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "SingleTargetAttackSkill", menuName = "Skill/Attack skill/Single target")]
public class SingleTargetAttack : AttackSkill
{
    private Hero chosenTarget;

    public override void PlayerChooseTarget(BattleSystem battleSystem)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (!hit)
            {
                return;
            }
            if (hit.transform.gameObject.GetComponent<Hero>().IsEnemy())
            {
                chosenTarget = hit.transform.gameObject.GetComponent<Hero>();
                battleSystem.activeCharacter.chosenEnemy.Add(chosenTarget);
                StartingExecuteSkill(battleSystem);
            }
        }
    }

    public override void EnemyChooseTarget(BattleSystem battleSystem)
    {
        int randTarget = Random.Range(0, battleSystem.activeCharacter.enemiesList.Count);
        chosenTarget = battleSystem.activeCharacter.enemiesList[randTarget];
        battleSystem.activeCharacter.chosenEnemy.Add(chosenTarget);
        StartingExecuteSkill(battleSystem);
    }

    public override void StartingExecuteSkill(BattleSystem battleSystem)
    {
        battleSystem.ClearButtons();
        battleSystem.StartCoroutine(Logic(battleSystem));
    }

    private IEnumerator Logic(BattleSystem battleSystem)   
    {
        battleSystem.activeCharacter.ShowActiveMarker(0);
        battleSystem.UseDarkVidget(0.5f);
        battleSystem.activeCharacter.ActiveLayer(2);
        battleSystem.activeCharacter.MoveForward(battleSystem);
        foreach (var enemy in battleSystem.activeCharacter.chosenEnemy)
        {
            enemy.ActiveLayer(2);
            enemy.MoveForward(battleSystem);
        }
        yield return new WaitForSeconds(1);
        battleSystem.activeCharacter.animator.SetTrigger("SingleHit");
        yield return new WaitForSeconds(1.5f);
        foreach (var enemy in battleSystem.activeCharacter.chosenEnemy)
        {
            enemy.MoveBack();
        }
        battleSystem.activeCharacter.MoveBack();
        yield return new WaitForSeconds(1);
        battleSystem.UseDarkVidget(0);
        battleSystem.activeCharacter.ActiveLayer(0);
        foreach (var enemy in battleSystem.activeCharacter.chosenEnemy)
        {
            enemy.ActiveLayer(0);
        }
        battleSystem.activeCharacter.chosenEnemy.Clear();
        battleSystem.activeCharacter.enemiesList.Clear();
        battleSystem.activeCharacter.SetAsNotReady();
        yield return new WaitForSeconds(1);
        battleSystem.SetState(battleSystem.CalculatingResultsState);
    }
}
