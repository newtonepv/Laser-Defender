using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float damage=10f;
    public float GetDamage()
    {
        return damage;
    }
    public void Hit(LayerMask layer)
    {
        if("player" == LayerMask.LayerToName(layer))
        {
            Destroy(gameObject);
        }
    }
}
