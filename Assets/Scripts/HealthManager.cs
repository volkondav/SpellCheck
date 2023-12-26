using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private int _currentHealth;

    void Update()
    {
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        _healthText.text = _currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
