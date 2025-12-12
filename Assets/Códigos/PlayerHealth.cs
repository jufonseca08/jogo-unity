using UnityEngine;
using UnityEngine.SceneManagement; // <-- 1. Importar o gerenciador de cenas

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;
    
    private Rigidbody2D rb;

    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void TakeDamage(float damage, Vector2 knockbackDirection, float knockbackForce = 10f)
    {
        currentHealth -= damage;
        Debug.Log("Player levou dano! Vida atual: " + currentHealth);
        
        // Aplica knockback
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Player morreu!");
        
        // 2. Desabilitamos o objeto do jogador, como você já estava fazendo.
        gameObject.SetActive(false); 

        // 3. Chamamos o método de reinício com um pequeno atraso de 2 segundos.
        // Isso dá tempo para a mensagem de 'Player morreu!' ser lida.
        Invoke("RestartCurrentScene", 2f); 
    }

    // 4. Novo método para reiniciar a cena
    void RestartCurrentScene()
    {
        // Pega o índice da cena atualmente ativa (ex: 0, 1, 2)
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recarrega a cena.
        SceneManager.LoadScene(currentSceneIndex);
    }
}