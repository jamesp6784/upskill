using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMain : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    public float lifeTime;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x;
        transform.position = new Vector2(xpos += moveSpeed, transform.position.y);
    }
}
