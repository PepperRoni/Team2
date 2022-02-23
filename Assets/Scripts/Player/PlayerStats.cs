using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    [Tooltip("Every X amount of seconds it'll add health")]
    [SerializeField] private float healthRegen;
                     private float healthTime;

    [Tooltip("Amount that get's added from HealthRegen")]
    [SerializeField] private float healthRegenAmount;



    [Header("Stamina")]
    [SerializeField] private float maxStamina;
    [SerializeField] private float stamina;

    [Tooltip("Every X amount of seconds it'll add stamina")]
    [SerializeField] private float staminaRegen;
                     private float staminaTime;

    [Tooltip("Amount that get's added from StaminaRegen")]
    [SerializeField] private float staminaRegenAmount;


    #region UnityOverwrites

    private void Update()
    {
        if (healthTime >= healthRegen)
        {
            healthTime = 0;
            AddHealth(healthRegenAmount);
        }

        if (staminaTime >= staminaRegen)
        {
            staminaTime = 0;
            AddStamina(staminaRegenAmount);
        }

        healthTime  = healthRegen  > 0 ? healthTime  + Time.deltaTime : 0;
        staminaTime = staminaRegen > 0 ? staminaTime + Time.deltaTime : 0;
    }

    private void Start()
    {
        health  = maxHealth;
        stamina = maxStamina;
    }

    #endregion

    private void Die()
    {
        print("💀");
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health < 0)
            Die();
    }

    public void AddHealth(float amount)
    {
        health += amount;

        if (health > maxHealth)
            health = maxHealth;

        //health = health + amount > maxHealth ? maxHealth : health + amount;
    }

    public void UseStamina(float amount)
    {
        stamina -= amount;

        if (stamina < 0)
            stamina = 0;

        //stamina = stamina - amount < 0 ? 0 : stamina - amount;
    }

    public void AddStamina(float amount)
    {
        stamina += amount;

        if (stamina > maxStamina)
            stamina = maxStamina;

        //stamina = stamina + amount > maxStamina ? maxStamina : stamina + amount; 
    }
}
