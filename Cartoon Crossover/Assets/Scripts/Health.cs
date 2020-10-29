using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    // The foreground gameObject
    public GameObject foreground;

    // The maximum health
    private int maxHealth;

    // The health of the current character
    private int currentHealth;

    // A test to make sure it works
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Makes the size of the health appropriate
    private void Update()
    {
        // The ratio between current and max health
        float healthRatio = (float)currentHealth / maxHealth;
        foreground.transform.localScale = new Vector3(healthRatio, 1, 1);
        foreground.transform.localPosition = new Vector3(healthRatio / 2 - 0.5f, 0, 0);

    }
    public void SetHealth(int health)
    {
        currentHealth = health;
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
    }
}
