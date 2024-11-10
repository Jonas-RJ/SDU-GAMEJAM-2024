using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    public AnimationCurve curve;
    public bool start = false;
    public float duration = 1.0f;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }

    }



   public IEnumerator Shaking()
    {
        Vector3 startposition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startposition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startposition;
    }
}
