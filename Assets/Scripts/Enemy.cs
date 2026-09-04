using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called, damage: " + damage);
        currentHealth -= damage;
        animator.SetTrigger("StunedTrigger");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Invoke("LoadBossScene", 2f);
    }

    private void LoadBossScene() 
    {
        SceneManager.LoadScene("BossScene");
    }
}
