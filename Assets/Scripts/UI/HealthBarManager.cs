using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager instance;
    [SerializeField]
    private Slider healthBarSlider;
    [SerializeField]
    private GameObject gameOver;
    private float currentHealth;
    private float maxHealth = 500f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        healthBarSlider.maxValue= maxHealth;
        healthBarSlider.minValue = 0f;

        // Thiết lập giá trị mặc định cho thanh máu
        currentHealth = maxHealth;
        healthBarSlider.value = currentHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Nếu máu hiện tại nhỏ hơn 0, đặt giá trị máu hiện tại về 0
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            gameOver.SetActive(true);
        }

        // Cập nhật giá trị thanh máu
        healthBarSlider.value = currentHealth;
    }
}
