using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class TogglePanelOnKeyPress : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The panel to toggle on key press.")]
    private GameObject panelToToggle;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel();
        }
    }

    public void ToggleInventoryPanel()
    {
        panelToToggle.SetActive(!panelToToggle.activeSelf);
    }
}