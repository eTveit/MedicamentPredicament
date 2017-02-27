using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerIcon : MonoBehaviour {

    public string workerType;

    void FixedUpdate() {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.parent.position, 5 * Time.deltaTime);
        }

    }
