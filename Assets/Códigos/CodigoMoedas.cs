using UnityEngine;

public class CoinMoedas : MonoBehaviour // O nome do arquivo DEVE ser CoinMoedas.cs
{
    // Valor que esta moeda adiciona ao placar
    public int coinValue = 1; 

    // Use OnTriggerEnter2D para jogos 2D. Se for 3D, use OnTriggerEnter(Collider other).
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Verifique se o objeto que colidiu é o jogador (pela Tag)
        if (other.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                // ⚠️ CORREÇÃO CS1061: Chama o método correto 'AddCoins'
                CoinManager.Instance.AddCoins(coinValue); 
            }
            
            // Destrói a moeda da cena
            Destroy(gameObject); 
        }
    }
}