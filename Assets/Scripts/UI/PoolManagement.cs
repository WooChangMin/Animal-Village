using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManagement : MonoBehaviour
{
    ItemDB itemDatabase;

    private int defaultPoolSize = 6;
    //private int defaultMaxSize = 12;

    private int equipPoolSize = 2;
    //private int equipMaxSize = 3;

    private List<GameObject> objectPool = new();

    public void Awake()
    {
        itemDatabase = GameManager.Resource.Load<ItemDB>("ItemDB/ItemDataBase");
        CreatePool();
    }

    private void CreatePool()
    {
        foreach (GameObject item in itemDatabase.items)
        {
            if (item.GetComponent<Item>().item.type == ItemType.Default)
            {
                for (int i = 0; i < defaultPoolSize; i++)
                {
                    GameObject poolingItem = Instantiate(item);
                    poolingItem.gameObject.SetActive(false);
                    poolingItem.transform.SetParent(transform);
                    objectPool.Add(poolingItem);
                }
            }
            else
            {
                for (int i = 0; i < equipPoolSize; i++)
                {
                    GameObject poolingItem = Instantiate(item);
                    poolingItem.gameObject.SetActive(false);
                    poolingItem.transform.SetParent(transform);
                     objectPool.Add(poolingItem);
                }
            }
        }
    }

    /*public GameObject Get(GameObject item)
    {
        if (objectPool.Count > 0)
        {
            GameObject poolingItem = objectPool.Remove(item);
            poolingItem.gameObject.SetActive(true);
            poolingItem.transform.parent = null;
            return poolingItem;
        }
        else
        {
            GameObject poolingItem = Instantiate(itemDatabase.items.)
            //poolable.Pool = this;
            return poolingItem;
        }
    }

    public void Release(GameObject poolingItem)
    {
        if (objectPool.Count < maxsize)
        {
            poolingItem.SetActive(false);
            poolingItem.transform.SetParent(transform);
            objectPool.Add(poolingItem);
        }
        else
            Destroy(poolingItem);
    }*/
}