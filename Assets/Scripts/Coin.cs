using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }
    void Jump(){
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().Play();
        float randomJumpForce = Random.Range(4f, 8f);//점프
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-1f, 1f);//좌우 이동
        rigidBody.AddForce(jumpVelocity,ForceMode2D.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
         if(transform.position.y < minY){
            Destroy(gameObject);
        }
    }
}
