using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class BattleSystem : BattleSystemLogic
{
    [SerializeField] private SpriteRenderer darkVidget;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterHP;
    [SerializeField] private TextMeshProUGUI characterAttack;
    public TextMeshProUGUI roundText;
    public int n = 1;
    public List<Hero> allCharactersList;
    public List<Hero> allHeroesList;
    public List<Hero> allEnemiesList;
    public List<SkillButton> skillButtons;
    public EndMenu endMenu;
    public Button waitButton;
    public Hero activeCharacter;

    public Transform heroPos;
    public Transform enemyPos;

    private BattleSystemBaseState currentState;
    public BattleSystemInitState InitState = new BattleSystemInitState();
    public BattleSystemStartRoundState StartRoundState = new BattleSystemStartRoundState();
    public BattleSystemGetActiveCharacter GetActiveCharacterState = new BattleSystemGetActiveCharacter();
    public BattleSystemPlayerChooseTarget PlayerChooseTargetState = new BattleSystemPlayerChooseTarget();
    public BattleSystemEnemyChooseTarget EnemyChooseTargetState = new BattleSystemEnemyChooseTarget();
    public BattleSystemResultsState CalculatingResultsState = new BattleSystemResultsState();
    public BattleSystemFinalState FinalState = new BattleSystemFinalState();

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

    public void SetCharacterInfo(Hero hero)
    {
        characterName.text = hero.nameCharacter;
        characterHP.text = "HP: " + hero.currentHP + "/" + hero.hp;
        characterAttack.text = "Attack: " + hero.minDamage + "-" + hero.maxDamage;
    }

    public void UseDarkVidget(float alphaValue)
    {
        darkVidget.DOFade(alphaValue, 0.5f);
    }

    public void SkipHero()
    {
        ClearButtons();
        activeCharacter.SetAsNotReady();
        activeCharacter.ShowActiveMarker(0);
        SetState(CalculatingResultsState);
    }

    public void ClearButtons()
    {
        foreach (var skillButton in skillButtons)
        {
            skillButton.button.interactable = false;
            skillButton.skillText.text = "";
        }
        waitButton.interactable = false;
    }
}
