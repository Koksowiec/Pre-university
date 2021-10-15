using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLightRed : MonoBehaviour
{
    Light testLight;
    public float minWaitTime;
    public float maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            Material mymat = GetComponent<Renderer>().material;
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;

            //Change material emission color
            if (!testLight.enabled)
            {

                mymat.SetColor("_EmissionColor", Color.black);
            }
            else
            {
                mymat.SetColor("_EmissionColor", Color.red);
            }
        }
    }
}
