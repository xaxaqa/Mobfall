using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Если нет SpriteRenderer, выводим предупреждение
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No SpriteRenderer attached to this enemy.");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashWhite()); // Запуск корутины мигания
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Уничтожаем врага, если здоровье 0 или меньше
    }

    private IEnumerator FlashWhite()
    {
        // Проверка, есть ли SpriteRenderer
        if (spriteRenderer != null)
        {
            Color originalColor = spriteRenderer.color;  // Сохраняем оригинальный цвет

            spriteRenderer.color = Color.white;  // Меняем цвет на белый
            yield return new WaitForSeconds(0.1f); // Ждём 0.1 секунды

            spriteRenderer.color = originalColor;  // Возвращаем исходный цвет
        }
    }
}