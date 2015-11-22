using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using GameObjectPool = FrispGames.ObjectPooling.GameObjectPool;

public class ObjectDestroyer : MonoBehaviour {

	public string TagToDestroy;

	void OnTriggerEnter2D (Collider2D other) {
		if(TagToDestroy == other.tag) {
			if(GameObjectPool.HasPool(other.tag)) {
				GameObjectPool pool = GameObjectPool.GetPool(other.tag);
				pool.RecycleObject(other.gameObject);
			} else {
				Destroy (other.gameObject);
			}
		}
	}
}
