using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
    private float[] arrPosX = {-2.0f,-1.0f,0f,1.10f,2.0f};

    [SerializeField]
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");

    }
    public void StopEnemyRoutine(){
        StopCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(3f); //대기시간

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;
        while(true){
            foreach(float posX in arrPosX){
                SpawnEnemy(posX,enemyIndex, moveSpeed);
            }
            spawnCount++;

            if(spawnCount % 10 == 0){
                enemyIndex ++;
                moveSpeed += 2;
            }

            if(enemyIndex >= enemies.Length){ // 보스 스폰
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }
        yield return new WaitForSeconds(spawnInterval); //대기
        }
    }
    void SpawnEnemy(float posX, int index, float moveSpeed){
        Vector3 spawnPos = new Vector3(posX, transform.position.y,transform.position.z);

        if(Random.Range(0,7)==0){ // 20%확률로 다음 단계의 적 스폰
            index += 1;
        }
        if(index >= enemies.Length){
            index -= 1;
        }
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }
    void SpawnBoss(){
        Instantiate(boss,transform.position,Quaternion.identity);
    }
}
