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
