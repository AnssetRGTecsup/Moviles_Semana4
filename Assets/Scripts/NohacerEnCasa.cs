using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NohacerEnCasa : MonoBehaviour
{
    public float waitTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InfiniteCo(waitTime));
    }

    private void Inifinte()
    {
        while (0 < 1)
        {
            Debug.Log("Hola Mundo");
        }
    }

    private IEnumerator InfiniteCo(float timeToWait)
    {
        Debug.Log("Hola Mundo 2");
        yield return new WaitForSeconds(timeToWait);
        Debug.Log("Hola Mundo 3");
        yield return new WaitForSeconds(timeToWait);

        StartCoroutine(InfiniteCo(waitTime));
    }

}
