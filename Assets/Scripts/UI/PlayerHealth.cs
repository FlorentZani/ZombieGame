using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    GameObject healthSprite = null;

    [SerializeField]
    Image spriteRenderer = null;

    float originalHealthValue, newHealthValue, differenceBetweenHealthValues;
    float originalHealthX, healthRatio, healthYScale, healthZScale;

    Color red, yellow, green;

    void Start()
    {
        originalHealthX = healthSprite.transform.localScale.x;
        healthYScale = healthSprite.transform.localScale.y;
        healthZScale = healthSprite.transform.localScale.z;
        healthRatio = 1f;
        red = Color.red;
        yellow = Color.yellow;
        green = Color.green;
    }

    public void DecreaseHealth(float amount)
    {
        SoundManager.Instance.PlaySound("Damage");
        healthRatio -= amount;
        originalHealthValue = spriteRenderer.minWidth;
        healthSprite.transform.localScale = new Vector3(originalHealthX * healthRatio, healthYScale, healthZScale);
        newHealthValue = spriteRenderer.minWidth;
        differenceBetweenHealthValues = originalHealthValue - newHealthValue;
        healthSprite.transform.Translate(new Vector3(differenceBetweenHealthValues, 0f, 0f));

        if (healthRatio <= 0.25f)
        {
            spriteRenderer.color = red;
        }
        else if(healthRatio <= 0.5f)
        {
            spriteRenderer.color = yellow;
        }
        else
        {
            spriteRenderer.color = green;
        }

        if (healthRatio <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
