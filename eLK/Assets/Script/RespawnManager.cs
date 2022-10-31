using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> Mobpool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;


    void Awake()
    {
        for (int i = 0; i < Mobs.Length; i++)
        {
            for (int j = 0; j < objCnt; j++)
            {
                Mobpool.Add(CreateObj(Mobs[i], transform));
                
            }
            
        }
    }

    private void Start()
    {
        StartCoroutine(CreateMob());
    }

    IEnumerator CreateMob()
    {
        while (true)
        {
            Mobpool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(9f, 12f));
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for(int i =0; i<Mobpool.Count; i++)
        {
            if (!Mobpool[i].activeSelf)
                num.Add(i);
        }
        int x = 0;
        if(num.Count >0)
        x = num[Random.Range(0, num.Count)];
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }

}
