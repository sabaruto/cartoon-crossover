using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightManager : MonoBehaviour {
    // The current fighter
    private bool isPlayerFighting;

    // The player and enemy
    public String playerName, enemyName;

    // The audio source
    private AudioSource source;
    public Character player;
    public CharacterEnemy enemy;

    // The meme renderer
    public Image memeRenderer;

    // The character sprite Images
    public GameObject playerCard, enemyCard;

    // The sprite renderers
    public SpriteRenderer playerRenderer, enemyRenderer;

    // The healthbars for the two cards
    public GameObject playerHealthBar, enemyHealthbar;

    // The scripts from the healthbars
    private Health playerHealth, enemyHealth;

    // The game objects for the enemies 
    public GameObject enemyButton1, enemyButton2, enemyButton3, enemyButton4;

    // The images of the enemy buttons
    private Image buttonImage1, buttonImage2, buttonImage3, buttonImage4;

    // The game objects of the buttons
    public GameObject button1, button2, button3, button4;

    // The main canvas
    public GameObject canvas;

    // The auio clips
    public AudioClip[] sounds;

    // The end game canvas
    public GameObject endGameCanvas;

    // The fader object
    public Fader currentFade;

    // The buttons for the abilities
    private Button ability1Button, ability2Button, ability3Button,
                  ability4Button;

    // The text for each button
    public TextMeshProUGUI  button1Message, button2Message, button3Message, 
                     button4Message;

    public TextMeshProUGUI  enemy1Message, enemy2Message, enemy3Message,
                            enemy4Message;

    public TextMeshProUGUI firstAttack, secondAttack, thirdAttack, fourthAttack;

    private bool isAttacking = true;

    // Checks if the game has ended
    private bool isGameFinished = false;

    // Checking if the player or enemy is shaking
    private bool isPlayerShaking = false, isEnemyShaking = false;

    // The initial position of the cards
    private Vector3 playerCardInitialPosition, enemyCardInitialPosition;

    // Start is called before the first frame update
    void Start() {

        source = GetComponent<AudioSource>();

        ability1Button = button1.GetComponent<Button>();
        ability2Button = button2.GetComponent<Button>();
        ability3Button = button3.GetComponent<Button>();
        ability4Button = button4.GetComponent<Button>();

        buttonImage1 = enemyButton1.GetComponent<Image>();
        buttonImage2 = enemyButton2.GetComponent<Image>();
        buttonImage3 = enemyButton3.GetComponent<Image>();
        buttonImage4 = enemyButton4.GetComponent<Image>();

        player = Characters.getCharacter(playerName);
        enemy = Enemies.getCharacter(enemyName);

        playerHealth = playerHealthBar.GetComponent<Health>();
        enemyHealth = enemyHealthbar.GetComponent<Health>();

        firstAttack.SetText("");
        secondAttack.SetText("");
        thirdAttack.SetText("");
        fourthAttack.SetText("");

        playerHealth.SetMaxHealth(player.health);
        enemyHealth.SetMaxHealth(enemy.health);

        playerCardInitialPosition = playerCard.transform.position;
        enemyCardInitialPosition = enemyCard.transform.position;

        ability1Button.onClick.AddListener(delegate { playerAttack(1); });
        button1Message.SetText(player.ability1.getName());
        enemy1Message.SetText(enemy.ability1.getName());
        ability2Button.onClick.AddListener(delegate { playerAttack(2); });
        button2Message.SetText(player.ability2.getName());
        enemy2Message.SetText(enemy.ability2.getName());
        ability3Button.onClick.AddListener(delegate { playerAttack(3); });
        button3Message.SetText(player.ability3.getName());
        enemy3Message.SetText(enemy.ability3.getName());
        ability4Button.onClick.AddListener(delegate { playerAttack(4); });
        button4Message.SetText(player.ability4.getName());
        enemy4Message.SetText(enemy.ability4.getName());

        isPlayerFighting = true;
    }

    // Update is called once per frame
    void Update() {

        if (isGameFinished) { return; }

        if (isPlayerShaking)
        {
            Vector3 shakeMovement = UnityEngine.Random.insideUnitSphere * 0.2f;
            shakeMovement.z = 0;
            playerCard.transform.position = playerCardInitialPosition + 
                                            shakeMovement;
        }

        if (isEnemyShaking)
        {
            Vector3 shakeMovement = UnityEngine.Random.insideUnitSphere * 0.2f;
            shakeMovement.z = 0;
            enemyCard.transform.position = enemyCardInitialPosition + 
                                           shakeMovement;
        }


        if (!isPlayerFighting)
        {
            if (isAttacking) 
            {
                isAttacking = false;
                StartCoroutine(EnemyFight());
            }
        } // enemy attacks
        else
        {
            Color normalColor = new Color(1, 1, 1);

            ability1Button.interactable=(player.ability1.checkCountDown() == 0);
            ability2Button.interactable=(player.ability2.checkCountDown() == 0);
            ability3Button.interactable=(player.ability3.checkCountDown() == 0);
            ability4Button.interactable=(player.ability4.checkCountDown() == 0);

            Color tempColor = enemyRenderer.color;
            tempColor.a = 0.5f;
            enemyRenderer.color = tempColor;

            tempColor = playerRenderer.color;
            tempColor.a = 1;
            playerRenderer.color = tempColor;
        }

        if (!player.isAlive() || !enemy.isAlive()) 
        {
            StartCoroutine(End()); 
            Debug.Log("Still Running");
        }

        // Updates the healthbars
        playerHealth.SetHealth(player.health);
        enemyHealth.SetHealth(enemy.health);
    } // update

    // Starts and ends the shaking
    private IEnumerator ShakeNow(bool isPlayer)
    {
        GameObject movingCard = (isPlayer) ? playerCard : enemyCard;

        if (isPlayer) isPlayerShaking = true; else isEnemyShaking = true;

        yield return new WaitForSeconds(0.5f);

        movingCard.transform.position = (isPlayer) ? playerCardInitialPosition 
                                                   : enemyCardInitialPosition;

        if (isPlayer) isPlayerShaking = false; else isEnemyShaking = false;
    }

    private IEnumerator EnemyFight()
    {
        Color tempColor = playerRenderer.color;
        tempColor.a = 0.5f;
        playerRenderer.color = tempColor;
        buttonImage1.color = tempColor;
        buttonImage2.color = tempColor;
        buttonImage3.color = tempColor;
        buttonImage4.color = tempColor;

        tempColor.a = 1;
        enemyRenderer.color = tempColor;

        yield return new WaitForSeconds(1.5f);

        System.Random randomNum = new System.Random();
        double enemyChoice = randomNum.NextDouble();

        bool isHeal = false;
        if (enemyChoice < 0.25)
        {
            if (enemy.ability1.damageCheck())
            {
                player.takeDamage(enemy.ability1.getValue());
                SetLastAttacks(enemy.ability1.toStringDamage());   
            }
            else
            {
                enemy.takeDamage(-enemy.ability1.getValue());
                SetLastAttacks(enemy.ability1.toStringHeal()); 
                isHeal = true;
            }
            buttonImage1.color = tempColor;
            
        }
        else if (enemyChoice < 0.5)
        {
            if (enemy.ability2.damageCheck())
            {
                player.takeDamage(enemy.ability2.getValue());
                SetLastAttacks(enemy.ability2.toStringDamage());
            }
            else
            {
                enemy.takeDamage(-enemy.ability2.getValue());
                SetLastAttacks(enemy.ability2.toStringHeal());
                isHeal = true;
            }
            buttonImage2.color = tempColor;
        }
        else if (enemyChoice < 0.75)
        {
            if (enemy.ability3.damageCheck())
            {
                player.takeDamage(enemy.ability3.getValue());
                SetLastAttacks(enemy.ability3.toStringDamage());  
            }
            else
            {
                enemy.takeDamage(-enemy.ability3.getValue());
                SetLastAttacks(enemy.ability3.toStringHeal());
                isHeal = true;
            }
            buttonImage3.color = tempColor;
        }
        else
        {
            if (enemy.ability4.damageCheck())
            {
                player.takeDamage(enemy.ability4.getValue());
                SetLastAttacks(enemy.ability4.toStringDamage());   
            }
            else
            {
                enemy.takeDamage(-enemy.ability4.getValue());
                SetLastAttacks(enemy.ability4.toStringHeal());
                isHeal = true;
            }
            buttonImage4.color = tempColor;
        }

        if (!isHeal)
        {
            isPlayerShaking = true;
            StartCoroutine(ShakeNow(true));
            yield return new WaitForSeconds(0.5f);
        }
        

        isPlayerFighting = true;
        isAttacking = true;
    }

  public void playerAttack(int abilityNumber) {

        if (isPlayerFighting)
        {
            switch (abilityNumber) {
                
                case 1:
                    if (player.ability1.checkCountDown() == 0) {

                        doAbility(player.ability1);
                        player.ability1.setCountDown();
                        
                        player.ability2.reduceCountDown();
                        player.ability3.reduceCountDown();
                        player.ability4.reduceCountDown();
                        isPlayerFighting = false;
                    }
                    break;
                case 2:
                    if (player.ability2.checkCountDown() == 0) {
                        doAbility(player.ability2);
                        player.ability2.setCountDown();


                        player.ability1.reduceCountDown();
                        player.ability3.reduceCountDown();
                        player.ability4.reduceCountDown();
                        isPlayerFighting = false;
                    }
                    break;
                case 3:
                    if (player.ability3.checkCountDown() == 0) {
                        doAbility(player.ability3);
                        player.ability3.setCountDown();

                        player.ability1.reduceCountDown();
                        player.ability2.reduceCountDown();
                        player.ability4.reduceCountDown();
                        isPlayerFighting = false;
                    }
                    break;
                case 4:
                    if (player.ability4.checkCountDown() == 0) {
                        doAbility(player.ability4);
                        player.ability4.setCountDown();

                        player.ability1.reduceCountDown();
                        player.ability2.reduceCountDown();
                        player.ability3.reduceCountDown();
                        isPlayerFighting = false;
                    }
                    break;
                default:
                    break;
            } // switch
        }
    } // playerAttack

    private void doAbility(Ability currentAbility)
    {
        string currentAttack;
        if (currentAbility.damageCheck())
        {
            enemy.takeDamage(currentAbility.getValue());
            currentAttack = currentAbility.toStringDamage();
            isEnemyShaking = true;
            StartCoroutine(ShakeNow(false));
        }
        else
        {
            player.takeDamage(-currentAbility.getValue());
            currentAttack = currentAbility.toStringHeal();
        }

        SetLastAttacks(currentAttack);
        source.clip = sounds[(int)UnityEngine.Random.Range(0, sounds.Length)];
        source.Play();
    }

    public void SetLastAttacks(string currentAttack)
    {
        fourthAttack.SetText(thirdAttack.text);
        thirdAttack.SetText(secondAttack.text);
        secondAttack.SetText(firstAttack.text);
        firstAttack.SetText(currentAttack);
    }

    // The script that ends the game and show the Meme at the end
    private IEnumerator End()
    {
        isGameFinished = true;
        canvas.SetActive(false);
        endGameCanvas.SetActive(true);

        if (!player.isAlive())
        {
            memeRenderer.sprite = Resources.Load<Sprite>(player.loseMeme);
            Debug.Log(memeRenderer.sprite);
        }
        else
        {
            memeRenderer.sprite = Resources.Load<Sprite>(player.winMeme);
            Debug.Log("Loaded Sprite");
        }
        
        yield return new WaitForSecondsRealtime(5);
        currentFade.Fade("CodeScene");
    }
}
