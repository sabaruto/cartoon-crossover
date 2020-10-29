using UnityEngine;
using System.Collections;

public class Enemies
{
    private static Ability energyBlast = new Ability("Energy Blast", 10, 0);
    private static Ability superStrength = new Ability("Super Strength", 11, 0);
    private static Ability mindControl = new Ability("Mind Control", 11, 0);
    private static Ability Hypnotise = new Ability("Hypnotise", 13, 0);
    public static CharacterEnemy Ultron = new CharacterEnemy("Ultron", 60, energyBlast, superStrength, mindControl, Hypnotise);


    private static Ability crash = new Ability("Crash", 21, 0);
    private static Ability powerPunch = new Ability("Power Punch", 22, 1);
    private static Ability destroy = new Ability("Destroy", 23, 2);
    private static Ability armedCombat = new Ability("Armed Combat", 26, 3);

    public static CharacterEnemy KingPin = new CharacterEnemy("Kingpin", 180, crash, powerPunch, destroy, armedCombat);


    private static Ability invisible = new Ability("Invisible", 35, 0);
    private static Ability adapt = new Ability("Adapt", 36, 0, false);
    private static Ability spikes = new Ability("spikes", 38, 0);
    private static Ability shapeshift = new Ability("Shapeshift", 40, 0);

    public static CharacterEnemy Venom = new CharacterEnemy("Venom", 400, invisible, adapt, spikes, shapeshift);


    private static Ability stab = new Ability("Stab", 40, 0);
    private static Ability decoy = new Ability("Decoy", 30, 0, false);
    private static Ability assassinate = new Ability("Assassinate", 42, 0);
    private static Ability astralProjection = new Ability("Astral Projection", 45, 0);

    public static CharacterEnemy Loki = new CharacterEnemy("Loki", 520, stab, decoy, assassinate, astralProjection);

    private static Ability costsEverything = new Ability("Costs Everything", 150, 0);
    private static Ability perfectlyBalanced = new Ability("Perfectly Balanced", 200, 0);
    private static Ability infinityStones = new Ability("Infinity Stones", 210, 0);
    private static Ability snap = new Ability("Snap", 350, 0);

    public static CharacterEnemy Thanos = new CharacterEnemy("Thanos", 4500, costsEverything, perfectlyBalanced, infinityStones, snap);

    public static CharacterEnemy getCharacter(string characterName) 
    {
        CharacterEnemy charToReturn = null;
        switch (characterName)
        {
            case "Ultron":
                charToReturn = Ultron.Copy();
                break;
            case "Kingpin":
                charToReturn = KingPin.Copy();
                break;
            case "Venom":
                charToReturn = Venom.Copy();
                break;
            case "Loki":
                charToReturn = Loki.Copy();
                break;
            case "Thanos":
                charToReturn = Thanos.Copy();
                break;
            default:
                break;
        }
        return charToReturn;
    } // getCharacter
}