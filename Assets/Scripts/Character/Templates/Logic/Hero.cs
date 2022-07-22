using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Hero : MonoBehaviour, IDamageable<int>, IKillable
{
    [SerializeField] private Character character;
    public int hp { get; private set; }
    public int currentHP { get; private set; }
    public string nameCharacter { get; private set; }
    public int minDamage { get; private set; }
    public int maxDamage { get; private set; }
    private bool isEnemy;
    private bool isReady;
    private bool isDead;
    [SerializeField] private Canvas hpCanvas;
    [SerializeField] private Slider hpBar;
    [SerializeField] private SpriteRenderer activeMarker;
    public Animator animator;
    private Vector3 currHeroPos;
    public List<Skill> skillsList;
    public List<Hero> enemiesList;
    public List<Hero> chosenEnemy;

    private void Start()
    {
        currHeroPos = transform.position;
        nameCharacter = character.nameCharacter;
        hp = character.hp;
        currentHP = character.currentHP;
        hpBar.maxValue = hp;
        minDamage = character.minDamage;
        maxDamage = character.maxDamage;
        isEnemy = character.isEnemy;
        isReady = character.isReady;
        isDead = character.isDead;
        foreach (var skill in character.skills)
        {
            skillsList.Add(skill);
        }
        SetCurrentHP();
    }

    public void ShowActiveMarker(float alphaValue)
    {
        activeMarker.DOFade(alphaValue, 0.5f);
    }

    public void SetCurrentHP()
    {
        hpBar.value = currentHP;
    }

    public void Die()
    {
        isDead = true;
        ActiveLayer(0);
        HideOnBoard();//
        Debug.Log(nameCharacter + " погиб");
    }

    public void DealDamage()
    {
        foreach (var enemy in chosenEnemy)
        {
            var damage = Random.Range(minDamage, maxDamage);
            enemy.TakeDamage(damage);
        }
    }

    public void TakeDamage(int takenDamage)
    {
        animator.SetTrigger("TakeDamage");
        currentHP -= takenDamage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        SetCurrentHP();
    }

    public void MoveForward(BattleSystem battleSystem)
    {
        if (isEnemy)
        {
            transform.DOMove(battleSystem.enemyPos.position, 1);
            
        }
        else
        {
            transform.DOMove(battleSystem.heroPos.position, 1);
        }
        transform.DOScaleX(transform.localScale.x + 0.2f, 1);
        transform.DOScaleY(transform.localScale.y + 0.2f, 1);
    }

    public void MoveBack()
    {
        transform.DOMove(currHeroPos, 1);
        transform.DOScaleX(transform.localScale.x - 0.2f, 1);
        transform.DOScaleY(transform.localScale.y - 0.2f, 1);
    }

    public void ActiveLayer(int layer)
    {
        hpCanvas.sortingOrder = layer;
        GetComponent<SortingGroup>().sortingOrder = layer;
    }

    public void HideOnBoard()
    {
        gameObject.SetActive(false);
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public bool IsReady()
    {
        return isReady;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetAsNotReady()
    {
        isReady = false;
    }

    public void SetAsReady()
    {
        isReady = true;
    }
}
