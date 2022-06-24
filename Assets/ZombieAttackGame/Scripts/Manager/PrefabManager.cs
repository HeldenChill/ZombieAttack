using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilitys;
public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Inst;

    private void Awake()
    {
        if(Inst == null)
        {
            Inst = this;
            return;
        }
        Destroy(gameObject);
    }
    public GameObject pool;
    Dictionary<string, Pool> poolData = new Dictionary<string, Pool>();

    public void CreatePool(GameObject obj)
    {
        if (!poolData.ContainsKey(obj.tag))
        {
            GameObject newPool = Instantiate(pool, Vector3.zero, Quaternion.identity);
            Pool poolScript = newPool.GetComponent<Pool>();
            poolScript.Initialize(10, obj);
            poolData.Add(obj.tag, poolScript);   
        }   
    }

    public void PushToPool(GameObject obj)
    {
        poolData[obj.tag].Push(obj);
    }

    public GameObject PopFromPool(string index)
    {
        return poolData[index].Pop();
    }
    
}
