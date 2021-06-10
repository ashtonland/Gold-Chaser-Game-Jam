using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomNum : MonoBehaviour
{
    public float min;
    public float max;

    public float timeOut;

    public Slider slider;

    void Start()
    {
        StartCoroutine(randNum());
    }

    public IEnumerator randNum()
    {
        yield return new WaitForSeconds(timeOut);

        slider.value = Random.Range(min, max);
    }
}
