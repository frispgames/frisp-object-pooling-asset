# Frisp Object Pooling

Unity asset that provides a basic interface for creating game object pools.

### What is a game object pool?
A game object pool is a collection of similar game objects that you recycle instead of creating and 
destroying new game objects all the time. Creating and destroying objects during runtime is quite expensive and
can cause lag on devices. 

### Example
Class for dropping objects from an empty:
```csharp
using UnityEngine;
using System.Collections;

public class DropObject : MonoBehaviour {

	private FrispGames.GameObjectPool _objectPool;

	public GameObject[] objectsToPool;
	public int PoolSize;
	public string PoolTag;

	void Start () {
		this._objectPool = FrispGames.GameObjectPool.CreatePool(objectsToPool, PoolSize, PoolTag);
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			Drop();
		}
	}

	private void Drop () {
		GameObject obj = _objectPool.GetObject ();
		obj.transform.position = transform.position;
		obj.SetActive (true);
	}
}
```
Class for the object destroyer:
```csharp
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectDestroyer : MonoBehaviour {

	public string TagToDestroy;

	void OnTriggerEnter2D (Collider2D other) {
		if(TagToDestroy == other.tag) {
			if(FrispGames.GameObjectPool.HasPool(other.tag)) {
				FrispGames.GameObjectPool pool = FrispGames.GameObjectPool.GetPool(other.tag);
				pool.RecycleObject(other.gameObject);
			} else {
				Destroy (other.gameObject);
			}
		}
	}
}

```
