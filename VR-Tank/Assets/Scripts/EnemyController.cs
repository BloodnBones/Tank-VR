using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {


    public bool NewWave = true;
    public int WaveCount = 1;
    public bool HaveSpawned = false;

    public GameObject EasyTank;
    public GameObject HardTank;
    public GameObject DroneFlock;
    public GameObject Buggy;
    // public GameObject Drone;

    public List<Transform> SpawnPoints;

    public float WaveTimer = 0;
    public bool CanSpawn = true;
    int Wave = 0;
    public float NextSpawn = 1.0f;

    // Use this for initialization
    void Start () {
        foreach (Transform t in transform)
        {
            if (t.gameObject != null && t != null)
            {
                Debug.Log(t.gameObject.name);
                SpawnPoints.Add(t);
                
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        //NextWave();

        WaveTimer += Time.deltaTime;
        if (WaveTimer > 6)
        {
            CanSpawn = true;
        }
        //if (!NewWave)
        //{
        //    NewWave = GameObject.Find("Nemesis").GetComponent<EnemyController>().GetNewWave();
        //}

        if (NewWave && CanSpawn)
        {
           // Debug.Log("So Far");
            NextWave();
        }

        GameObject[] EasyAi;
        EasyAi = GameObject.FindGameObjectsWithTag("Easy");

        GameObject[] HardAI;
        HardAI = GameObject.FindGameObjectsWithTag("Hard");

        

        if (EasyAi.Length == 0 && HardAI.Length == 0 && HaveSpawned)
        {
            NewWave = true;
            WaveCount += 1;
            HaveSpawned = false;
        }
        if (EasyAi.Length != 0 || HardAI.Length != 0)
        {
            HaveSpawned = true;
            NewWave = false;
        }

    }

    void NextWave()
    {
        //GameObject[] EasyAi;
        //EasyAi = GameObject.FindGameObjectsWithTag("Easy");
        
        //GameObject[] HardAI;
        //HardAI = GameObject.FindGameObjectsWithTag("Hard");

        //Debug.Log(EasyAi.Length);
        
        //if (EasyAi.Length == 0 && HardAI.Length == 0 && HaveSpawned)
        //{
        //    NewWave = true;
        //    WaveCount += 1;
        //    HaveSpawned = false;
        //}
        //if (EasyAi.Length != 0 || HardAI.Length != 0)
        //{
        //    HaveSpawned = true;
        //    NewWave = false;
        //    Debug.Log("MM");
        //}

        WaveTimer = 0;
        //First Easy Wave
        if (Wave < 3)
        {
            for(int i = 0; i < 4 * SpawnPoints.Count ;i++)
            {
              //  Debug.Log("Easy Spawn");
                StartCoroutine("ProcedualSpawn", EasyTank);
                NextSpawn += 2.0f;
            }
            if(Buggy != null)
            {
                for (int i = 0; i < 1 * SpawnPoints.Count; i++)
                {
                    //  Debug.Log("Easy Spawn");
                    StartCoroutine("ProcedualSpawn", Buggy);
                    NextSpawn += 2.0f;
                }
            }

            NewWave = false;
            NextSpawn = 1.0f;
        }
        //Mix of Easy and Hard
        else if (Wave > 3 && Wave < 5)
        {
            for(int i = 0; i < 3 * SpawnPoints.Count; i++)
            {
               // StartCoroutine("ProcedualSpawn", EasyTank);
                NextSpawn += 2.0f;
            }
            for(int j = 0; j < 1 * SpawnPoints.Count; j++)
            {
                 //   StartCoroutine("ProcedualSpawn", HardTank);
                    NextSpawn += 2.0f;
            }

            NewWave = false;
            NextSpawn = 1.0f;
        }
        //Full Hard Mode
        else
        {
            for(int j = 0; j < 4 * SpawnPoints.Count; j++)
            {
                StartCoroutine("ProcedualSpawn", HardTank);
                NextSpawn += 2.0f;
            }

            NewWave = false;
            NextSpawn = 1.0f;
        }
        CanSpawn = false;

    }
    
   public bool GetNewWave()
    {
        return NewWave;
    }

    public int GetLevel()
    {
        return WaveCount;
    }


    IEnumerator ProcedualSpawn(GameObject obj)
    {
        yield return new WaitForSeconds(NextSpawn);
        if (SpawnPoints.Count > 0)
        {
            GameObject clone;
            Transform spawnPos = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
            clone = Instantiate(obj, spawnPos.position, transform.rotation) as GameObject;
        }
    }

}
