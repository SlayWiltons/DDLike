using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BattleSystem : BattleSystemLogic
{
    public int n = 1;
    public List<Hero> allCharactersList;
    public List<Hero> allHeroesList;
    public List<Hero> allEnemiesList;
    public List<SkillButton> skillButtons;
    public Button waitButton;
    public Hero activeCharacter;

    private BattleSystemBaseState currentState;
    public BattleSystemInitState InitState = new BattleSystemInitState();
    public BattleSystemStartRoundState StartRoundState = new BattleSystemStartRoundState();
    public BattleSystemGetActiveCharacter GetActiveCharacterState = new BattleSystemGetActiveCharacter();
    public BattleSystemAwaitingOrders AwaitingOrdersState = new BattleSystemAwaitingOrders();
    public BattleSystemPlayerChooseTarget PlayerChooseTargetState = new BattleSystemPlayerChooseTarget();
    public BattleSystemEnemyChooseTarget EnemyChooseTargetState = new BattleSystemEnemyChooseTarget();
    public BattleSystemResultsState CalculatingResultsState = new BattleSystemResultsState();



    private void Start()
    {
        currentState = InitState;
        currentState.StartingState(this);
    }

    private void Update()
    {
        currentState.ProceedingState(this);
    }

    public void SetState(BattleSystemBaseState state)
    {
        currentState = state;
        state.StartingState(this);
    }

    public void SkipHero()
    {
        Debug.Log("Button Wait pressed");
        activeCharacter.SetAsNotReady();
        SetState(GetActiveCharacterState);
        Debug.Log(activeCharacter.IsReady());
    }

    
    
}
