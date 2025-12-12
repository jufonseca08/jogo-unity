using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // Adicionado para a função de reinício (se precisar)

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    // Conexões com a UI (Arraste os objetos para cá no Inspector)
    public TextMeshProUGUI coinText; 
    public GameObject victoryPanel; // Agora referenciamos o Painel inteiro
    
    private int currentCoins = 0; 
    private int totalCoinsInScene = 0;

    private void Awake()
    {
        // Padrão Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ⚠️ CORREÇÃO CS0246: Encontra objetos do tipo 'CoinMoedas'
        // Se o nome do seu script de moeda for diferente, mude 'CoinMoedas' aqui.
        totalCoinsInScene = FindObjectsOfType<CoinMoedas>().Length; 
        
        UpdateCoinDisplay();
        
        // Garante que o painel de vitória esteja invisível no começo
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        
        // Garante que o jogo não esteja pausado de uma sessão anterior
        Time.timeScale = 1f; 
    }

    // Método PÚBLICO chamado pelo script da moeda
    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinDisplay();
        
        // Checa se coletou tudo
        if (currentCoins >= totalCoinsInScene && totalCoinsInScene > 0)
        {
            Victory();
        }
    }

    private void UpdateCoinDisplay()
    {
        coinText.text = "Moedas: " + currentCoins.ToString();
    }

    void Victory()
    {
        Debug.Log("PARABÉNS! VOCÊ VENCEU!");
        
        if (victoryPanel != null)
        {
            // Ativa e mostra o Painel de Vitória (Texto + Botão)
            victoryPanel.SetActive(true);
            
            // Pausa o jogo
            Time.timeScale = 0f; 
        }
    }

    // Método para Reiniciar a Cena (útil, mas o botão fará isso)
    public void RestartCurrentScene()
    {
        Time.timeScale = 1f; // Despausa o jogo antes de carregar
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}