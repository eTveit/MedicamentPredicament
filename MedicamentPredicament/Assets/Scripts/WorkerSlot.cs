using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSlot : MonoBehaviour {

    public GameObject slottedWorker;
    private string workerType;

    void FixedUpdate() {
        if (slottedWorker != null) {
            if (slottedWorker.transform.parent != this.transform) slottedWorker.transform.SetParent(this.transform);
            }
        else {
            if (transform.childCount > 1) {
                slottedWorker = transform.GetChild(1).gameObject;
                }
            }
        }

    public string GetWorkerType() {
        if (slottedWorker != null) workerType = slottedWorker.GetComponent<WorkerIcon>().workerType;
        return workerType;
        }
    }
