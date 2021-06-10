using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public float lifeTime;
    public float speed;

    void Start()
    {
        Invoke("DestroyPlatform", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    private void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
