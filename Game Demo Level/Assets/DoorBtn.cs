using Assets;
using UnityEngine;

public class DoorBtn : Interactable
{
    public GameObject Target;
    private bool interacted = false;
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
        var cubeRenderer = transform.GetComponent<Renderer>();
        //open door if not already.
        if (!interacted)
        {
            cubeRenderer.material.SetColor("_Color", Color.green);
            Target.transform.eulerAngles = new Vector3(0, 90, 0);
            //interacted = true;
        }
        else
        {
            //close door
            cubeRenderer.material.SetColor("_Color", Color.red);
            Target.transform.eulerAngles = new Vector3(0, 0, 0);
            interacted = false;
        }
    }
    public override void Interact()
    {
        //Trigger from raycast
        HandleInteraction();
    }
}
