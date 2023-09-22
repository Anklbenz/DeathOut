using System;
using UnityEngine;
public class Brick : MonoBehaviour, IDamageable {
	[SerializeField] protected int hitPoints;
	public event Action<Brick> HitPointsOutEvent;

	public void Hit(int power) {
		hitPoints -= power;
		NotifyIfHitPointsOut();
	}
	
	private void NotifyIfHitPointsOut() {
		if (hitPoints <= 0)
			HitPointsOutEvent?.Invoke(this);
	}
}
