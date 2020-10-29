using System;
public class Ability
{
    private bool isDamage = true;
    private readonly string name;
    private readonly int damage;
    private readonly int heal;
    private int countDown;
    private readonly int maxCountDown;

    public Ability(string theName, int theDamage, int requiredMaxCountDown, bool isDamage = true)
    {
        name = theName;
        damage = theDamage;
        maxCountDown = requiredMaxCountDown;
        heal = theDamage;
        this.isDamage = isDamage;
    }//Ability constructor

    public int getValue()
    {
        return damage;
    }//getDamge


    public void reduceCountDown()
    {
        if (countDown != 0)
        {
            countDown--;
        }//if
    }//reduceCountDown

    public void setCountDown()
    {
        countDown = maxCountDown;
    }//setCountDown

    public int checkCountDown()
    {
        return countDown;
    }//checkCountDown
    public string toStringDamage()
    {
        return "The " + name + " ability dealt " + damage + " damage";
    }//toStringDamage
    
    public bool damageCheck()
    {
        return isDamage;
    }
    //damageCheck
    public string toStringHeal()
    {
        return "The " + name + " healed " + heal + " health";
    }//toStringHeal

    public string getName()
    {
        return name;
    }
}//Ability class