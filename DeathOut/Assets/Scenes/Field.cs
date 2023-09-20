
using System;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class Field : MonoBehaviour
{
    private const float STEP = 0.5f;

    [SerializeField] private Vector2Int size;
    [SerializeField] private Color gridColor = Color.white;
    [SerializeField] private GameObject plane;
    private Vector3 realSize => new Vector3(size.x, 0, size.y) * STEP;
    private Vector3 sizeExtends => new Vector3(size.x, 0, size.y) / 2;

    private void OnValidate() {
        plane.transform.localScale = realSize;
    }

    private void OnGUI() {
     //   Vector3 mouseWorld =Even.mousePosition;
      //  Debug.Log(mouseWorld);
        //var ray = SceneView.currentDrawingSceneView.camera.ScreenPointToRay(mouseWorld);
       // Physics.Raycast(ray, out var hit);
        
       // Debug.Log(hit.point);
    }

    private void OnDrawGizmos() {
        Gizmos.color = gridColor;
        for (int i = 0; i <= size.x; i++) {
            var origin = (new Vector3(i, 0, 0) - sizeExtends) * STEP;
            var destination = (new Vector3(i, 0, size.y) - sizeExtends) * STEP;
            Gizmos.DrawLine(origin, destination);
        }

        for (int i = 0; i <= size.y; i++) {
            var origin = (new Vector3(0, 0, i) - sizeExtends) * STEP;
            var destination = (new Vector3(size.x, 0, i) - sizeExtends) * STEP;
            Gizmos.DrawLine(origin, destination);
        }
    }
}
