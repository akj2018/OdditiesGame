using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
 
    [SerializeField] private float moveSpeed;
    
    public Item item;
    


    public void Initialize(Item item) {
        this.item = item;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            bool canAdd = InventoryManager.instance.AddItem(item);
            if(canAdd) {
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(MoveAndCollect(collision.transform));
            }
        } 
    }

    private IEnumerator MoveAndCollect(Transform target) {
        GetComponent<Collider2D>().enabled = false;

        while(transform.position != target.position) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }

        Destroy(gameObject);
    }

}
