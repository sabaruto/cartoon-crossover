using UnityEngine;
using System.Collections;

public class Characters
{
    private static string resources = "winlossMemes/";
    private static Ability quickAttack = new Ability("Quick Attack", 8, 0);
    private static Ability voltTackle = new Ability("Volt Tackle", 10, 1);
    private static Ability thunder = new Ability("Thunder", 15, 1);
    private static Ability thunderbolt = new Ability("Thunderbolt", 20, 1);
    public static Character Pikachu = new Character("Pikachu", 50, quickAttack,
                                                     voltTackle, thunder, thunderbolt, resources + "pikaWin", resources + "pika");

    private static Ability bookSmash = new Ability("Book Smash", 20, 1);
    private static Ability cheeseTrap = new Ability("Cheese Trap", 25, 1);
    private static Ability chase = new Ability("Chase", 30, 1);
    private static Ability fryingPan = new Ability("Frying Pan", 40, 3);

    public static Character Tom = new Character("Tom", 150, bookSmash,
                                                 cheeseTrap, chase, fryingPan, resources + "tomWin", resources + "tomLoss");
    private static Ability chunga = new Ability("Chunga", 25, 0, false);
    private static Ability chonga = new Ability("Chonga", 35, 1);
    private static Ability changa = new Ability("Changa", 35, 2);
    private static Ability bigChenga = new Ability("Big Chenga", 60, 3);

    public static Character BigChungus = new Character("Big Chungus", 375,
                                                       chunga, chonga, changa, bigChenga, resources + "bigChungusWin", resources + "bigChungusLoss");

    private static Ability potOfGreed = new Ability("Pot of Greed", 40, 0, false);
    private static Ability shadowRealm = new Ability("Shadow Realm", 47, 1);
    private static Ability slifer = new Ability("Slifer", 50, 3);
    private static Ability exodia = new Ability("Exodia", 1000000, 10);

    public static Character Yugi = new Character("Yugi", 500, potOfGreed,
                                                 shadowRealm, slifer, exodia, resources + "yugiohWin", resources + "yugiohLoss");

    private static Ability tenPercent = new Ability("Ten Percent", 100, 0);
    private static Ability choke = new Ability("Choke", 200, 1);
    private static Ability scoobySnack = new Ability("Scooby Snack", 400, 3, false);
    private static Ability ultraInstinct = new Ability("Ultra Instinct", 500, 3);

    public static Character Shaggy = new Character("Shaggy", 4000, tenPercent,
                                                    choke, scoobySnack, ultraInstinct, resources + "shaggyWin", resources + "shaggyLoss");

    public static Character getCharacter(string characterName) 
    {
        Character charToReturn = null;
        switch (characterName)
        {
            case "Pikachu":
                charToReturn = Pikachu.Copy();
                break;
            case "Tom":
                charToReturn = Tom.Copy();
                break;
            case "Big Chungus":
                charToReturn = BigChungus.Copy();
                break;
            case "Yugi":
                charToReturn = Yugi.Copy();
                break;
            case "Shaggy":
                charToReturn = Shaggy.Copy();
                break;
            default:
                break;
        }
        return charToReturn;
    } // getCharacter
}
