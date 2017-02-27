using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnMouseOver : MonoBehaviour {

    public GameObject highlight;
    private bool slotIsAvailable;

    void Update() {
        if (this.GetComponent<WorkerSlot>().slottedWorker == null) {
            slotIsAvailable = true;
            }
        else {
            slotIsAvailable = false;
            }
        }

    void OnMouseEnter() {
        if (slotIsAvailable) highlight.SetActive(true);
        }

    void OnMouseExit() {
        highlight.SetActive(false);
        }
    }
