using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class getInput : MonoBehaviour
{
    public InputField mainInputField;

    public Fader currentFade;

    public void Start()
    {
        mainInputField = GetComponent<InputField>();
        mainInputField.text = "Enter Text Here...";
    }//Start

    public void Update()
    {
        // Debug.Log(mainInputField.text);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (mainInputField.text == "UltronUsed:EnergyBlast")
            {
                currentFade.Fade("UltronvsPikachu");
            }//if
            if (mainInputField.text == "YoureDeadSpiderMan")
            {
                currentFade.Fade("KingpinvsTom");
            }//if
            if (mainInputField.text == "LikeATurdInTheWind")
            {
                currentFade.Fade("VenomvsBigChungus");
            }//if
            if (mainInputField.text == "IveNeverSeenThisManInMyLife")
            {
                currentFade.Fade("LokivsYugi");
            }//if
            if (mainInputField.text == "AsAllThingsShouldBe")
            {
                currentFade.Fade("ThanosvsShaggy");
            }//if
        }//if
    }//U[date
}//getInput
