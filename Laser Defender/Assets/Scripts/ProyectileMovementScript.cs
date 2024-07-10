using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileMovementScript : MonoBehaviour
{
    [SerializeField] bool spins;
    [SerializeField] float spinningSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinningSpeed * Time.deltaTime);
    }
}
