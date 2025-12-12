using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    private Rigidbody2D rb;

    public HealthBar healthBar; // O script da sua barra de vida
    
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void TakeDamage(float damage, Vector2 knockbackDirection, float knockbackForce = 10f)
    {
        if (currentHealth <= 0) return; // Se já estiver morto, ignore o dano

        currentHealth -= damage;
        Debug.Log("Player levou dano! Vida atual: " + currentHealth);
        
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Player morreu!");
        
        // Desabilita o objeto do jogador imediatamente
        gameObject.SetActive(false); 

        // Chama o método de reinício após 2 segundos de atraso
        Invoke("RestartCurrentScene", 2f); 
    }

    void RestartCurrentScene()
    {
        // Despausa o jogo, caso ele tenha sido pausado
        Time.timeScale = 1f; 
        
        // 1. Pega o índice da cena atualmente ativa
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 2. Recarrega a cena.
        SceneManager.LoadScene(currentSceneIndex);
    }
}