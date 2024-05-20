using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public float moveSpeed;
    public float health;
    public float damageDisplayTime;
    private float currentHealth;

    SpriteRenderer spriteRenderer;
    [SerializeField]
    Color hit;
    Color regular;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        regular = spriteRenderer.color;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        float posx = this.transform.position.x + moveSpeed * Time.deltaTime;
        this.transform.position = new Vector2(posx, this.transform.position.y);
    }

    public void DamageEnemy(float damage)
    {
        currentHealth-=damage;
        StartCoroutine(DamageDisplay(damageDisplayTime));

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log($"{gameObject.name} health: {currentHealth}");
    }

    private IEnumerator DamageDisplay(float damageTime)
    {
        spriteRenderer.color = hit;
        yield return new WaitForSeconds(damageTime);
        spriteRenderer.color = regular;
    }
}
