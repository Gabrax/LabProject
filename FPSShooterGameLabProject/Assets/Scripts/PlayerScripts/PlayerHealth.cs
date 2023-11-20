using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipseed = 2f;
    public Image frontHealthBar;
    public Image Frame;
    private bool isDead;
    public DeathScreen death;
    public AudioSource hp;
    public AudioSource dmg;
    public GameObject pauseDestroy;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if(health <= 0 && !isDead)
        {
            isDead = true;
            
            death.GameOver();
            Destroy(pauseDestroy);
            Debug.Log("Dead");
        }
    }
    public void UpdateHealthUI()
    {
        
        float fillF = frontHealthBar.fillAmount;
        float fillB = Frame.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            Frame.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipseed;
            percentComplete = percentComplete * percentComplete;
            Frame.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction) 
        {
            Frame.color = Color.green;
            Frame.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipseed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, Frame.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        dmg.pitch = (Random.Range(0.6f, .9f));
        dmg.Play();
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        hp.pitch = (Random.Range(0.6f, .9f));
        hp.Play();
    }
}
