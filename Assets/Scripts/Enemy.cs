using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    
    private float minY = -7f;
    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < minY){
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other) { //충돌 처리
        if(other.gameObject.tag == "Weapon"){ //무기로 적을 맞췄을 경우
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0){
                if(gameObject.tag == "Boss"){
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                    Instantiate(coin, transform.position,Quaternion.identity);
                }
                Destroy(gameObject);//적 삭제
                
                Instantiate(coin, transform.position,Quaternion.identity);
            }
            Destroy(other.gameObject);//미사일 삭제

        }
    }
}
