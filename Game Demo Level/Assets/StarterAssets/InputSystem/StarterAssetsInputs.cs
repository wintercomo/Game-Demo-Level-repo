using Assets;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{

    public class StarterAssetsInputs : MonoBehaviour
    {
        public float range = 2;
        public GameObject InteractionRaySpawn;
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
#endif
        public void OnInteract(InputValue value)
        {
            Debug.Log("Pressed interaction button");
            Vector3 direction = Vector3.forward;
            var raySpawn = InteractionRaySpawn.transform.position;
            Ray theRay = new Ray(raySpawn, transform.TransformDirection(direction * range));
            Debug.DrawRay(raySpawn, transform.TransformDirection(direction * range));


            if (Physics.Raycast(theRay, out RaycastHit hit, range))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                Debug.Log(hit.collider.name);
                if (interactable != null)
                {
                    interactable.Interact();
                    //HandleInteraction(interactable);
                }
            }
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}