using UnityEngine;
using System.Collections;

public class CharacterEnemy
{

    public string name;
    public int health;

    private int maxHealth;
    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
    public Ability ability4;

    public bool alive;

    public CharacterEnemy(string charName, int charHeath, Ability abl1, Ability abl2, Ability abl3, Ability abl4)
    {
        name = charName;
        health = charHeath;
        maxHealth = charHeath;
        ability1 = abl1;
        ability2 = abl2;
        ability3 = abl3;
        ability4 = abl4;
        alive = true;
    } // Constructor

    public bool isAlive()
    {
        return alive;
    }//isAlive

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            health = 0;
            alive = false;
        }//if
        else if(health > maxHealth)
        {
            health = maxHealth;
        }
    } // takeDamage

    
    public CharacterEnemy Copy()
    {
        return new CharacterEnemy(name, health, ability1, ability2, ability3,
                                  ability4);
    }
}//CharacterEnemies