using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FrispGames.ObjectPooling {
	public class GameObjectPool {
		
		private static Dictionary<string, GameObjectPool> _poolCache = new Dictionary<string, GameObjectPool> ();
		
		private GameObject[] _objectsToPool;
		private Queue<GameObject> _objectPool;
		private string _objectTag;
		private int _poolSize;
		
		public static GameObjectPool CreatePool(GameObject[] objectsToPool, int poolSize, string poolTag) {
			GameObjectPool pool;
			
			if (_poolCache.TryGetValue (poolTag, out pool)) {
				return pool;
			} else {
				pool = new GameObjectPool (objectsToPool, poolSize);
				pool.Fill();
				_poolCache.Add(poolTag, pool);
				return pool;
			}
		}
		
		public static GameObjectPool GetPool(string poolTag) {
			GameObjectPool pool;
			
			if (_poolCache.TryGetValue (poolTag, out pool)) {
				return pool;
			} else {
				return null;
			}
		}
		
		public static bool HasPool(string poolTag) {
			return _poolCache.ContainsKey (poolTag);
		}
		
		public GameObject GetObject() {
			if (_objectPool.Count > 0) {
				return _objectPool.Dequeue ();
			} else {
				return Object.Instantiate(RandomObjectToPool());
			}
		}
		
		public void RecycleObject(GameObject obj) {
			obj.SetActive (false);
			_objectPool.Enqueue (obj);
		}

		private void Fill() {
			this._objectPool = new Queue<GameObject> ();
			
			for (int i = 0; i < _poolSize; i++) {
				GameObject obj = Object.Instantiate(RandomObjectToPool());
				obj.SetActive(false);
				_objectPool.Enqueue(obj);
			}
		}

		private GameObjectPool(GameObject[] objectsToPool, int poolSize) {
			this._objectsToPool = objectsToPool;
			this._poolSize = poolSize;
		}
		
		private GameObject RandomObjectToPool() {
			int index = Random.Range (0, _objectsToPool.Length);
			return _objectsToPool[index];
		}
	}
}