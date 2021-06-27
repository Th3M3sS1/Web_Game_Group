using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float currentHealth;
    public float maxHealth;

    public Image healthBar;

    public virtual void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0.0f)
        {
            OnDeath();
        }
        
    }
}
