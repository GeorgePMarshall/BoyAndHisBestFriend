using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(OutlineShader))]
public class OutlineShaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        OutlineShader script = (OutlineShader)target;


        if (GUILayout.Button("Toggle"))
        {
            script.outline = !script.outline;
        }

    }
}
#endif



public class OutlineShader : MonoBehaviour {

    GameObject outlineObject;
    [SerializeField]Material outlineMaterial;
    bool outlineEnabled;
    Material[] outlinedMaterials;
    Material[] defaultMaterial;
    
	// Use this for initialization
	void Start ()
    {
        //load outline material
		if (GetComponent<Renderer> () == null)
			return;

        if(outlineMaterial == null)
            outlineMaterial = Resources.Load("OutlineScale", typeof(Material)) as Material;

        outlinedMaterials = new Material[2];
        outlinedMaterials[0] = GetComponent<Renderer>().material;
        outlinedMaterials[1] = outlineMaterial;

        defaultMaterial = new Material[1];
        defaultMaterial[0] = GetComponent<Renderer>().material;

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //outlines object
    public bool outline
    {
        get
        {
            return outlineEnabled;
        }

        set
        {
            outlineEnabled = value;
			if (GetComponent<Renderer> () == null)
				return;


            if (outlineEnabled == true)
            {
                GetComponent<Renderer>().materials = outlinedMaterials;
            }
            else
            {
                GetComponent<Renderer>().materials = defaultMaterial;
            }
        }
    }
    
}


