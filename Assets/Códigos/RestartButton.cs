using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Método PÚBLICO que será chamado ao clicar no botão
    public void RestartGame()
    {
        // 1. Despausa o jogo
        Time.timeScale = 1f; 

        // 2. Pega o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 3. Recarrega a cena (reiniciando o jogo)
        SceneManager.LoadScene(currentSceneIndex);
    }
}