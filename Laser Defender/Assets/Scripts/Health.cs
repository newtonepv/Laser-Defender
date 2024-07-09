using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    DamageDealing damageDealingScriptOfTheMostRecentAttacker;
    [SerializeField] float health = 100f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        damageDealingScriptOfTheMostRecentAttacker = collider.GetComponent<DamageDealing>();
        if (damageDealingScriptOfTheMostRecentAttacker != null)
        {
            int layer = this.gameObject.layer;
            damageDealingScriptOfTheMostRecentAttacker.Hit(layer);
            TakeDamage(damageDealingScriptOfTheMostRecentAttacker.GetDamage());
        }
    }

    private void TakeDamage(float damage)
    {
        Debug.Log("Damage taken: " + damage);
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}
