using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosions;
    bool canBeDestroyed = false;

    public GameObject[] itemDrops;
    GameObject dropItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= 8.60f && !canBeDestroyed )
        {
            canBeDestroyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                Ship.ScoreUlt += 1;
                DestroyDestructable();
                Destroy(bullet.gameObject);
                ItemDrop();
            }
        }
    }
    void DestroyDestructable()
    {
        Instantiate(explosions, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[Random.Range(0, itemDrops.Length)], transform.position + new Vector3(0,1, 0), Quaternion.identity);
        }
    }
}
