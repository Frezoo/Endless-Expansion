using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuController : MonoBehaviour
{
    [Header("Конпки")]
    [SerializeField] private Button startNewGameButton;
    [SerializeField] private Button resumeGameButton;


    private void Awake()
    {
        startNewGameButton.onClick.AddListener(StartGame);
        resumeGameButton.onClick.AddListener(resumeGame);
        if (YG2.isFirstGameSession)
        {
            SaveManager.Instance.FirstStartSetup();
        }
    }

    private void StartGame()
    {
        SaveManager.Instance.SetDefaultParams();
        SceneManager.LoadScene(1);
    }

    private void resumeGame()
    {
        SceneManager.LoadScene(1);
    }
}
