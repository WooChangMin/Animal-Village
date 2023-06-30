using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] ItemDB itemDatabase;

    public static ObjectPool instance;

    private Stack<Poolable> objectPool = new Stack<Poolable>();

    private int defaultPoolSize = 6;
    private int defaultMaxSize = 12;

    private int equipPoolSize = 2;
    private int equipMaxSize = 3;


    [SerializeField] Poolable poolablePrefab;

    [SerializeField] int poolSize;
    [SerializeField] int maxSize;



    private void Awake()

    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Poolable poolable = Instantiate(poolablePrefab);
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            poolable.Pool = this;
            //objectPool.Push(poolable);
        }
    }

    public Poolable Get()
    {
        if (objectPool.Count > 0)
        {
            Poolable poolable = objectPool.Pop();
            poolable.gameObject.SetActive(true);
            poolable.transform.parent = null;
            return poolable;
        }
        else
        {
            Poolable poolable = Instantiate(poolablePrefab);
            poolable.Pool = this;
            return poolable;
        }
    }

    public void Release(Poolable poolable)
    {
        if (objectPool.Count < maxSize)
        {
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            objectPool.Push(poolable);
        }
        else
        {
            Destroy(poolable.gameObject);
        }
    }
}
/*{
    private Stack<PooledObject> objectPool = new Stack<PooledObject>();
    private int poolSize = 100;

    public void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            objectPool.Push(new PooledObject());
        }
    }

    public PooledObject GetPool()
    {
        if (objectPool.Count > 0)
            return objectPool.Pop();
        else
            return new PooledObject();
    }

    public void ReturnPool(PooledObject pooled)
    {
        objectPool.Push(pooled);
    }
}

public class PooledObject
{
    // 생성&삭제가 빈번한 클래스
}*/