using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float damage=10f;
    Health health;
    private void Start()
    {
         TryGetComponent<Health>(out health);
    }
    public float GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        if (health != null)
        {
            health.ActivateExplosionEffect(transform.position);
        }
        Destroy(gameObject);
        
    }
}
