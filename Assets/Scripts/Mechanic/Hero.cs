using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Hero : MonoBehaviour, IDamageable<int>, IKillable
{
    [SerializeField] private Character character;
    [SerializeField] private int hp;
    private string nameCharacter;
    private bool isEnemy;
    [SerializeField] private bool isReady;
    private bool isDead;
    public List<Skill> skillsList;
    public List<Hero> enemiesList;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = character.sprite;
        nameCharacter = character.nameCharacter;
        hp = character.hp;
        isEnemy = character.isEnemy;
        isReady = character.isReady;
        isDead = character.isDead;
        foreach (var skill in character.skills)
        {
            skillsList.Add(skill);
        }
    }

    public void Die()
    {
        isDead = true;
        Debug.Log(nameCharacter + " погиб");
    }

    public void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
        if (hp <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log(nameCharacter + " получил " + takenDamage + " урона");
        }
    }

    public void SetEnemiesList(BattleSystem battleSystem)
    {
        enemiesList.Clear();
        foreach (var hero in battleSystem.allCharactersList)
        {
            if (!isEnemy)
            {
                if (hero.isEnemy)
                {
                    enemiesList.Add(hero);
                }
            }
            else
            {
                if (!hero.isEnemy)
                {
                    enemiesList.Add(hero);
                }
            }
        }
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
