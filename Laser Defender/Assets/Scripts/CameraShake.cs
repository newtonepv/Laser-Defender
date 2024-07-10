using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration;
    [SerializeField] float eachPositionDuration;
    [SerializeField] float shakeDefaultMagnitude;
    Vector3 initialPosition;
    Coroutine shakingCamera;
    private void Awake()
    {
        initialPosition = transform.position;
    }
    private void Start()
    {
    }
    public void Play()
    {
        if(shakingCamera!=null){
            StopCoroutine(shakingCamera);
            shakingCamera = StartCoroutine(Shake());
        }
        else
        {
            shakingCamera = StartCoroutine(Shake());
        }
    }
    IEnumerator Shake()
    {
        for(int i = 0; i < shakeDuration / eachPositionDuration; i++)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeDefaultMagnitude;
            yield return new WaitForSeconds(eachPositionDuration);
            transform.position = initialPosition;
            yield return new WaitForSeconds(eachPositionDuration);
        }
    }
}
