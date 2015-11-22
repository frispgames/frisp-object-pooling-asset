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
