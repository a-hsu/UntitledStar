using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy_AnimController))]
[CanEditMultipleObjects]
public class Enemy_AnimControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Enemy_AnimController enemy = (Enemy_AnimController)target;
        if (GUILayout.Button("Move to Target"))
        {
            enemy.isMoving = true;
            enemy.StartCoroutine(enemy.RootMotion());
            enemy.StartCoroutine(enemy.ProceduralWalk());
        }
        if(GUILayout.Button("Stop Movement"))
        {
            enemy.isMoving = false;
            enemy.StopCoroutine(enemy.RootMotion());
            enemy.StopCoroutine(enemy.ProceduralWalk());
        }
    }
}
