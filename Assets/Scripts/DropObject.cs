using UnityEngine;
using System.Collections;

using GameObjectPool = FrispGames.ObjectPooling.GameObjectPool;

public class DropObject : MonoBehaviour {

	private GameObjectPool _objectPool;

	public GameObject[] ObjectsToPool;
	public int PoolSize;
	public string PoolTag;

	void Start () {
		this._objectPool = GameObjectPool.CreatePool(objectsToPool, PoolSize, PoolTag);
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			Drop();
		}
	}

	private void Drop () {
		GameObject obj = _objectPool.GetObject ();
		obj.transform.position = transform.position;
	}
}
