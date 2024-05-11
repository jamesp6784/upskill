using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    BasicEnemy enemyStats;
    DartMain dartStats;

    // Start is called before the first frame update
    void Start()
    {
        dartStats = GetComponent<DartMain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            enemyStats = collision.transform.GetComponent<BasicEnemy>();
            enemyStats.DamageEnemy(dartStats.damage);
            Destroy(this.gameObject);
        }
    }
}
