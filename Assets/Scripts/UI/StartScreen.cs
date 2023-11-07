using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    Button startGameButton = null;

    void Awake()
    {
        startGameButton.onClick.AddListener(HandleStartGameButtonClicked);
    }

    void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(HandleStartGameButtonClicked);
    }

    void HandleStartGameButtonClicked()
    {
        SceneManager.LoadSceneAsync("MissionObjective");
    }
}
