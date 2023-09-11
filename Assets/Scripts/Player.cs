using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShootTime = 0f;
    void Update()
    {
        //키보드로 입력받기
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // //float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo*moveSpeed*Time.deltaTime;

        //키보드로 입력받기2
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime,0,0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // } else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }

        //Debug.Log(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f,2.35f);
        float toY = Mathf.Clamp(mousePos.y, -4.2f,4.2f);
        transform.position = new Vector3(toX,toY,transform.position.z);
        //Debug.Log(mousePos);
        if(GameManager.instance.isGameOver == false){
            Shoot();
        }
        
     }
     void Shoot(){
        if(Time.time-lastShootTime > shootInterval){
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShootTime = Time.time;
        }
     }
     private void OnTriggerEnter2D(Collider2D other) { //충돌시
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin"){ //코인과 충돌
            GetComponent<AudioSource>().Play();
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
     }
     public void Upgrade(){
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length){
            weaponIndex = weapons.Length -1;
        }
     }
}
