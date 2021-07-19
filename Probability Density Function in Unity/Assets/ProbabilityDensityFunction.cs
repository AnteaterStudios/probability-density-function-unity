using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityDensityFunction : MonoBehaviour
{
    public float Speed;
    public float Amplitude;
    public float Height;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowCurve(Speed, Amplitude, Height));
    }

    IEnumerator FollowCurve(float speed, float amplitude, float height)
    {
        //function: e^(-(1/2)*((x/a)^2))*h

        float initialPos = -5f;
        this.transform.position = new Vector3(initialPos, 0, 0);

        float x = initialPos;
        float y;

        while (true)
        {
            y = Mathf.Exp((-.5f) * Mathf.Pow( x / amplitude, 2)) * height;

            Debug.Log(y);

            x += Time.deltaTime * speed;

            this.transform.position = new Vector3(x, y, this.transform.position.z);

            yield return null;
        }
    }
}
