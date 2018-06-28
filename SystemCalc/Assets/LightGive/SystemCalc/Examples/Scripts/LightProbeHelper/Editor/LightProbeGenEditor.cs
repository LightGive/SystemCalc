using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LightProbeGenerator))]
public class LightProbeGenEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if( GUILayout.Button( "Generate" ) )
		{
			( target as LightProbeGenerator ).GenProbes();
		}
		
		EditorGUILayout.Separator();
		
		if( GUILayout.Button( "Clear" ) )
		{
			( target as LightProbeGenerator ).ClearProbes();
		}

	}
	
	public void OnSceneGUI()
	{
		LightProbeGenerator gen = target as LightProbeGenerator;
		if (Tools.current == Tool.Move)
		{
			bool edited = false;

			for(int i = 0; i < gen.LightProbeVolumes.Length; i++)
			{
				Vector3 oldCenter = gen.LightProbeVolumes[i].ProbeVolume.center;
				gen.LightProbeVolumes[i].ProbeVolume.center = Handles.PositionHandle(
					gen.LightProbeVolumes[i].ProbeVolume.center, Quaternion.identity
					);
				
				if (oldCenter != gen.LightProbeVolumes[i].ProbeVolume.center)
				{
					edited = true;
				}
				
			}
        	if (GUI.changed)
			{
            	EditorUtility.SetDirty (target);			
			}
	        
			if (edited)
	        {
				Undo.SetSnapshotTarget(target, "ProbeGenerator Move");
	            Undo.CreateSnapshot();
	            Undo.RegisterSnapshot();
	        }			
		}
			
		if (Tools.current == Tool.Scale)
		{
			bool edited = false;
			
			for(int i = 0; i < gen.LightProbeVolumes.Length; i++)
			{
				Vector3 oldScale = gen.LightProbeVolumes[i].ProbeVolume.extents;
				gen.LightProbeVolumes[i].ProbeVolume.extents = Handles.ScaleHandle (
							gen.LightProbeVolumes[i].ProbeVolume.extents, 
	                        gen.LightProbeVolumes[i].ProbeVolume.center,
	                        Quaternion.identity,
	                        5.0f);
				if (oldScale != gen.LightProbeVolumes[i].ProbeVolume.extents)
				{
					edited = true;
				}
				
			}

			if (GUI.changed)
			{
            	EditorUtility.SetDirty (target);			
			}
			
			if (edited)
	        {
				Undo.SetSnapshotTarget(target, "ProbeGenerator Scale");
	            Undo.CreateSnapshot();
	            Undo.RegisterSnapshot();
	        }			
		}
	}
}