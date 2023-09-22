using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   public Transform paddleOrigin;
   public List<Brick> bricks= new List<Brick>();
   public Vector3 paddlePosition => paddleOrigin.position;

   public event Action AllBricksDestroyedEvent;
   public event Action<Vector3> BrickDestroyedEvent;
   
   public void Initialize() {
     foreach (var brick in bricks)
         brick.HitPointsOutEvent += OnBrickDestroy;
   }
        
   private void OnBrickDestroy(Brick sender) {
       
      BrickDestroyedEvent?.Invoke(sender.transform.position);
            
      if(bricks.Count <=0)
         AllBricksDestroyedEvent?.Invoke();
   }
}
   