using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBAr hbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hbar.setMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            takeDamage(15);
        }
    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        hbar.setHealth(currentHealth);
    }
}
