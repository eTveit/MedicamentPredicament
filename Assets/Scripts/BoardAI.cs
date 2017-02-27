using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAI : MonoBehaviour {
    public GameObject cardPrefab;
    public Transform cardSpawn;
    public GameObject corpProjCard;
    public GameObject workProjCard;
    public Transform corpProjContainer;
    public Transform[] corpProjSlots;
    public Transform workProjContainer;
    public Transform[] workProjSlots;
    public Transform[] logWorkerSlots;
    public Transform[] proWorkerSlots;
    public Transform[] stoWorkerSlots;
    public Transform[] shiWorkerSlots;
    public Transform[] resourceSlots;
    public GameObject workerPrefab;

    // Use this for initialization
    void Start() {
        GameObject w1 = HireWorker("Logistics");
        GameObject w2 = HireWorker("Production");
        GameObject w3 = HireWorker("Shipping");
        GameObject w4 = HireWorker("Shipping");
        GameObject w5 = HireWorker("Logistics");
        GameObject w6 = HireWorker("Production");
        GameObject w7 = HireWorker("Storage");
        GameObject w8 = HireWorker("Storage");
        w1.transform.SetParent(workProjSlots[0]);
        w2.transform.SetParent(workProjSlots[3]);
        w3.transform.SetParent(corpProjSlots[1]);
        w4.transform.SetParent(resourceSlots[0]);
        w5.transform.SetParent(resourceSlots[5]);
        w6.transform.SetParent(resourceSlots[7]);
        w7.transform.SetParent(corpProjSlots[2]);
        w8.transform.SetParent(resourceSlots[1]);
        }

    void FixedUpdate() {
        if (corpProjCard == null) NewCorpProject();
        if (workProjCard == null) NewWorkProject();
        if (Input.GetKeyDown(KeyCode.C)) {
            print("corp");
            ReturnWorkersFromProject("corp");
            }
        if (Input.GetKeyDown(KeyCode.W)) {
            print("work");
            ReturnWorkersFromProject("work");
            }
        if (Input.GetKeyDown(KeyCode.R)) {
            print("resource");
            ReturnWorkersFromResource();
            }
        }



    void NewCorpProject() {
        corpProjCard = Instantiate(cardPrefab, cardSpawn.position, Quaternion.identity);
        corpProjCard.transform.SetParent(corpProjContainer);
        }

    void NewWorkProject() {
        workProjCard = Instantiate(cardPrefab, cardSpawn.position, Quaternion.identity);
        workProjCard.transform.SetParent(workProjContainer);
        }

    void ReturnWorkersFromProject(string project) {
        if (project == "corp") {
            for (int i = 0; i < corpProjSlots.Length; i++) {
                if (corpProjSlots[i].GetComponent<WorkerSlot>().slottedWorker != null) {
                    string type = corpProjSlots[i].GetComponent<WorkerSlot>().GetWorkerType();
                    corpProjSlots[i].GetComponent<WorkerSlot>().slottedWorker.transform.SetParent(FindParentSlot(type));
                    corpProjSlots[i].GetComponent<WorkerSlot>().slottedWorker = null;
                    }
                }
            }
        else if (project == "work") {
            for (int i = 0; i < workProjSlots.Length; i++) {
                if (workProjSlots[i].GetComponent<WorkerSlot>().slottedWorker != null) {
                    string type = workProjSlots[i].GetComponent<WorkerSlot>().GetWorkerType();
                    workProjSlots[i].GetComponent<WorkerSlot>().slottedWorker.transform.SetParent(FindParentSlot(type));
                    workProjSlots[i].GetComponent<WorkerSlot>().slottedWorker = null;
                    }
                }
            }
        }

    void ReturnWorkersFromResource() {
        for (int i = 0; i < resourceSlots.Length; i++) {
            if (resourceSlots[i].GetComponent<WorkerSlot>().slottedWorker != null) {
                string type = resourceSlots[i].GetComponent<WorkerSlot>().GetWorkerType();
                resourceSlots[i].GetComponent<WorkerSlot>().slottedWorker.transform.SetParent(FindParentSlot(type));
                Worker recourceReciever = FindWorkerPlayer(type);
                GiveResource(i, recourceReciever);
                resourceSlots[i].GetComponent<WorkerSlot>().slottedWorker = null;
                }
            }
        }

    void GiveResource(int i, Worker worker) {
        switch (i) {
            case 0:
            case 1:
                worker.happiness += 1;
                break;
            case 2:
            case 3:
                worker.energy += 1;
                break;
            case 4:
            case 5:
                worker.influence += 1;
                break;
            case 6:
            case 7:
                worker.money += 1;
                break;
            }
        }


    Transform FindParentSlot(string type) {
        switch (type) {
            case "Logistics":
                if (logWorkerSlots[0].GetComponent<WorkerSlot>().slottedWorker == null) return logWorkerSlots[0];
                else return logWorkerSlots[1];
            case "Production":
                if (proWorkerSlots[0].GetComponent<WorkerSlot>().slottedWorker == null) return proWorkerSlots[0];
                else return proWorkerSlots[1];
            case "Storage":
                if (stoWorkerSlots[0].GetComponent<WorkerSlot>().slottedWorker == null) return stoWorkerSlots[0];
                else return stoWorkerSlots[1];
            case "Shipping":
                if (shiWorkerSlots[0].GetComponent<WorkerSlot>().slottedWorker == null) return shiWorkerSlots[0];
                else return shiWorkerSlots[1];
            default:
                return this.transform;
            }
        }

    GameObject HireWorker(string type) {
        GameObject newWorker = Instantiate(workerPrefab, cardSpawn.position, Quaternion.identity);
        newWorker.transform.SetParent(FindParentSlot(type));
        newWorker.GetComponent<WorkerIcon>().workerType = type;
        return newWorker;
        }

    Worker FindWorkerPlayer(string type) {
        if (type == "Logistics") return GetComponent<Logistics>();
        else if (type == "Production") return GetComponent<Production>();
        else if (type == "Storage") return GetComponent<Storage>();
        else if (type == "Shipping") return GetComponent<Shipping>();
        else return null;
        }

    }
