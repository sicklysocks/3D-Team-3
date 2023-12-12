using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfTheView))]
public class FOVEditor : Editor
{
  private void OnSceneGUI()
  {
      FieldOfTheView fov = (FieldOfTheView)target;
      Handles.color = Color.red; //show radius in red
      Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

      Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
      Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

      Handles.color = Color.yellow; //show fov in yellow
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
      Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

      if (fov.canSeePlayer)
        {
            Handles.color = Color.blue; //show where CPS is looking in blue when in range (can see player)
            Handles.DrawLine(fov.transform.position, fov.Player.transform.position);
        }
    }
  
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
