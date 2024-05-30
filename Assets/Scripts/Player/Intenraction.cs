using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intenraction : MonoBehaviour
{
    [SerializeField] float checkRate = 0.05f;
    private float lastCheckTime;
    [SerializeField] float maxCheckDistance;
    [SerializeField] LayerMask layerMask;

    [SerializeField] GameObject curInteractGameObject;
    private IInterattable curInteractable;

    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;

    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            Debug.DrawRay(new Vector3(Screen.width / 2, Screen.height / 2),Vector3.forward*maxCheckDistance, Color.red);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInterattable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                itemNameText.gameObject.SetActive(false);
                itemDescriptionText.gameObject.SetActive(false);
            }
        }
    }
    private void SetPromptText()
    {
        itemNameText.gameObject.SetActive(true);
        itemDescriptionText.gameObject.SetActive(true);

        itemNameText.text = curInteractable.GetInteractName();
        itemDescriptionText.text = curInteractable.GetInteractDescription();
    }

    
}
