using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class mashFusion : MonoBehaviour {
	void Start() {
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length) {
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.active = false;
			i++;
		}
		transform.GetComponentInChildren<MeshFilter>().mesh = new Mesh();
		transform.GetComponentInChildren<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.active = true;
	}
}