using Assets;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DoorBtn : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleInteraction()
    {
        //Logic for interaction
        Debug.Log("Interaction called");
        var cubeRenderer = transform.GetComponent<Renderer>();

        // Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.green);
        Debug.Log("Color set to green");
    }
    public override void Interact()
    {
        //Trigger from raycast
        HandleInteraction();
    }
}
