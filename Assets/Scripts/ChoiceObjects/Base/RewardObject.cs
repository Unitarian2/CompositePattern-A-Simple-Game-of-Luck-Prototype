using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class RewardObject : MonoBehaviour
{
    public float maxXrotation;
    public float maxYrotation;
    public float maxZrotation;

    public List<Mesh> meshes;

    public abstract float Value { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        GiveRandomRotation();
        SelectRandomMesh();
    }

    private void SelectRandomMesh()
    {
        int index = Random.Range(0, meshes.Count);
        GetComponent<MeshFilter>().mesh = meshes[index];
    }

    private void GiveRandomRotation()
    {
        float xRotation = Random.Range(-maxXrotation, maxXrotation);
        float yRotation = Random.Range(-maxYrotation, maxYrotation);
        float zRotation = Random.Range(-maxZrotation, maxZrotation);
        gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
