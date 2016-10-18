using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawn : MonoBehaviour
{

    public bool NewWave = true;
    public bool CanSpawn = true;
    public int Wave = 0;
    public List<GameObject> EnemyUnits;
    public List<GameObject> HardEnemies;

    public float NextSpawn = 1.0f;
    int HardCount = 0;
    public float WaveTimer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaveTimer += Time.deltaTime;
        if( WaveTimer > 6)
        {
            CanSpawn = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !NewWave)
        {
            NewWave = true;
        }

        if (NewWave && CanSpawn)
        {
            Wave += 1;
            NextWave();
            NewWave = false;
        }

        NewWave = false;
    }

    void NextWave()
    {
        WaveTimer = 0;
        //First Easy Wave
        if (Wave < 3)
        {
            foreach (GameObject obj in EnemyUnits)
            {
                StartCoroutine("ProcedualSpawn", obj);
                NextSpawn += 2.0f;
            }

            NewWave = false;
            NextSpawn = 1.0f;
        }
        //Mix of Easy and Hard
        else if (Wave > 3 && Wave < 5)
        {
            foreach (GameObject obj in EnemyUnits)
            {
                StartCoroutine("ProcedualSpawn", obj);
                NextSpawn += 2.0f;
            }
            foreach (GameObject obj in HardEnemies)
            {
                if (HardCount < 1)
                {
                    StartCoroutine("ProcedualSpawn", obj);
                    NextSpawn += 2.0f;
                    HardCount += 1;
                }
            }

            NewWave = false;
            NextSpawn = 1.0f;
            HardCount = 0;
        }
        //Full Hard Mode
        else
        {
            foreach (GameObject obj in HardEnemies)
            {
                StartCoroutine("ProcedualSpawn", obj);
                NextSpawn += 2.0f;
            }

            NewWave = false;
            NextSpawn = 1.0f;
        }
        CanSpawn = false;
    }

    IEnumerator ProcedualSpawn(GameObject obj)
    {
        yield return new WaitForSeconds(NextSpawn);
        GameObject clone;
        Vector3 spawnPos = transform.position;
        clone = Instantiate(obj, spawnPos, transform.rotation) as GameObject;

    }

}
