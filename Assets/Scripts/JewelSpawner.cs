using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class JewelSpawner : MonoBehaviourPun
{
    public GameObject jewelPrefab;
    public int maxJewels = 5;

    private void Start()
    {
        StartCoroutine(JewelSpawnRoutine());
    }

    IEnumerator JewelSpawnRoutine()
    {
        while (true)
        {
            JewelSpawn();
            yield return new WaitForSeconds(5f);
        }
    }
    
    void JewelSpawn()
    {
        if (!PhotonNetwork.IsMasterClient || jewelPrefab == null)
            return;

        int amountOfJewels = GameObject.FindGameObjectsWithTag("Jewel").Length;
        if(amountOfJewels < maxJewels)
        {
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-8f, 8f);
            pos.y = Random.Range(-4f, 4f);
            pos.z = 0f;

            PhotonNetwork.Instantiate(jewelPrefab.name, pos, Quaternion.identity);
        }
    }
}
