using UnityEngine;
using System.Collections;

public class Character
{

    public string name;
    public int health;

    private int maxHealth;
    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
    public Ability ability4;
    public string winMeme;
    public string loseMeme;

    public bool alive;

    public Character(string charName, int charHealth, Ability abl1, Ability abl2, Ability abl3, Ability abl4, string meme1, string meme2)
    {
        name = charName;
        health = charHealth;
        maxHealth = charHealth;
        winMeme = meme1;
        loseMeme = meme2;
        ability1 = abl1;
        ability2 = abl2;
        ability3 = abl3;
        ability4 = abl4;
        alive = true;

        if (ability4.getName() == "Exodia")
        {
            ability4.setCountDown();
        }
    }// Constructor

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

        else if (health > maxHealth)
        {
          health = maxHealth;
        }
    } // takeDamage

    public Character Copy()
    {
        return new Character(name, health, ability1, ability2, ability3,
                             ability4, winMeme, loseMeme);
    }

}//Character
