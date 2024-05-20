using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMain : MonoBehaviour, IPlaceable
{

    [SerializeField] GameObject dart;
    public float shootSpeed;
    Vector2 bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        float posY = this.transform.position.y;
        bulletSpawn = new Vector2(this.transform.position.x, posY + 0.2f);
        StartCoroutine(ShootTime(shootSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        int layerMask = LayerMask.GetMask("Enemy");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);

        if (hit)
        {
            Instantiate(dart, bulletSpawn, Quaternion.identity, this.transform);
            Debug.Log($"{hit.collider.name}");
        }
        
    }

    private IEnumerator ShootTime(float shootTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            Action();
        }
    }
}
