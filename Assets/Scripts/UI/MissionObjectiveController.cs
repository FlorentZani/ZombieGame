using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionObjectiveController : MonoBehaviour
{
    [SerializeField]
    Button startButton = null;

    void Awake()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
    }

    void OnDestroy()
    {
        startButton.onClick.RemoveListener(HandleStartButtonClicked);
    }

    void HandleStartButtonClicked()
    {
        SoundManager.Instance.PlaySound("UI2");
        SceneManager.LoadScene("Level");
    }
}
