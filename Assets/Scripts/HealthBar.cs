using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    //update the health bar
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        if (fillImage == null)
        {
            Debug.LogError("Fill Image is NOT assigned!");
            return;
        }

        float percent = currentHealth / maxHealth;
        fillImage.fillAmount = percent;
    }

}