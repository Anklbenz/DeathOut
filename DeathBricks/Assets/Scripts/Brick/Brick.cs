
using System;
using UnityEngine;



    public class Brick : MonoBehaviour, IDamageable
    {
        [SerializeField] protected int hitPoints;
        public event Action<Brick> LifeOutEvent;

        private ParticleSystem _hitParticles;


        public void Hit(int power) {
            hitPoints -= power;

            if (hitPoints <= 0)
                LifeOutEvent?.Invoke(this);
        }
    }
