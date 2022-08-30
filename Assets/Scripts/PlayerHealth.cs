using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int currentHealth;
    public int maxHealth;

    public float damageInvincLenght = 1f;
    private float invisCount;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        //UIController.instance.healthSlider.maxValue = maxHealth;
        //UIController.instance.healthSlider.value = currentHealth;
        //UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (invisCount > 0)
        {
            invisCount -= Time.deltaTime;

            if(invisCount <= 0)
            {
            PlayerMovement.instance.bodySR.color = new Color(PlayerMovement.instance.bodySR.color.r, PlayerMovement.instance.bodySR.color.g, PlayerMovement.instance.bodySR.color.b, 1f);
            }
        }    
    }

    public void DamagePlayer()
    {
        if(invisCount <= 0)
        {
            AudioManager.instance.PlaySFX(11);
            currentHealth--;

            invisCount = damageInvincLenght;

            PlayerMovement.instance.bodySR.color = new Color(PlayerMovement.instance.bodySR.color.r, PlayerMovement.instance.bodySR.color.g, PlayerMovement.instance.bodySR.color.b, 0.5f);

         
            if(currentHealth <= 0)
       
            {
        
                PlayerMovement.instance.gameObject.SetActive(false);

            
                UIController.instance.deathScreen.SetActive(true);

            
                AudioManager.instance.PlayGameOver();
            
                AudioManager.instance.PlaySFX(8);
            }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();    
        } 
    }
    public void makeInvincible(float length)
    {
        invisCount = length;
        PlayerMovement.instance.bodySR.color = new Color(PlayerMovement.instance.bodySR.color.r, PlayerMovement.instance.bodySR.color.g, PlayerMovement.instance.bodySR.color.b, 0.5f);
    }

    public void HealPlayer (int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
         
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
