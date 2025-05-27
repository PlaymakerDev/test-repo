using UnityEngine;

public class Player : MonoBehaviour
{
    private LayerMask mask;
    private Vector3 direction;
    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }
    void Update()
    {
        direction = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, direction * 5f, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, 5f, mask))
            {
                Debug.Log("Hit something");
                Debug.Log(hit);
                IInteractable comp = hit.collider.gameObject.GetComponent<IInteractable>();
                comp.Interact();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.OpenInventoryPanel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.instance.CloseInventoryPanel();
        }
    }
}
