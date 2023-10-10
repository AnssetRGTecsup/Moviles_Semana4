using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SimpleObjectPooling myPooling;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float speed;
    private bool isSetUp;

    private void OnEnable()
    {
        myPooling.onEnableObject += SetUp;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= SetUp;
    }

    private void SetUp()
    {
        if (!isSetUp)
        {
            //TO DO SET UP
            if(myRigidbody == null)
            {
                myRigidbody = GetComponent<Rigidbody2D>();
            }

            myRigidbody.velocity = Vector3.down * speed;

            isSetUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.tag == "Player")
        {
            //TO DO DAMAGE
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }

        if(collision.tag == "Collector")
        {
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }
    }
}
