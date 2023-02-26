using System;


using UnityEngine;

public class Level : MonoBehaviour
{
   [SerializeField]public Transform paddleOrigin;
   public Vector3 paddlePosition => paddleOrigin.position;
   public Bricks bricks;

   public event Action AllBricksDestroyedEvent;
   public event Action<Vector3> BrickDestroyedEvent;
   
   public void Initialize() {
      bricks.Initialize();

      foreach (var brick in bricks)
         brick.LifeOutEvent += OnBrickDestroy;
   }
        
   private void OnBrickDestroy(Brick sender) {
      bricks.Destroy(sender);
      BrickDestroyedEvent?.Invoke(sender.transform.position);
            
      if(bricks.count <=0)
         AllBricksDestroyedEvent?.Invoke();
   }
}
   