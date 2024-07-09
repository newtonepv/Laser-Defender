using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    DamageDealing damageDealing;
    [SerializeField] float health = 100f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision between layer: ");
        Debug.Log(LayerMask.LayerToName(collider.gameObject.layer));
        Debug.Log(" and layer: ");
        Debug.Log(LayerMask.LayerToName(this.gameObject.layer));
        damageDealing = collider.GetComponent<DamageDealing>();
        if (damageDealing != null)
        {
            damageDealing.Hit();
            TakeDamage(damageDealing.GetDamage());
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
