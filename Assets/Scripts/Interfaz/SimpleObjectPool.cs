using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour {

    public GameObject prefab;
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();
    //Push: add an object on the stack.
    //Pop: remove and return the first object on the stack.
    //Peek: get the first object without removing it.

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if (inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            //Se crea una instancia mientras no existan instancias inactivas
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        //Detaches the transform from its parent.
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);
        return spawnedGameObject;
    }

    public void ReturnObject(GameObject toReturn)
    {

        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if (pooledObject != null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }
        else
        {
            Destroy(toReturn);
        }
    }
}

public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}
