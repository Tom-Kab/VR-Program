using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveListManager : MonoBehaviour
{
    public Transform objectiveContainer;
    public GameObject objectivePrefab;

    private void Start()
    {
        // Create objectives and add them to the list
        CreateObjective("Task 1: Collect items");
        CreateObjective("Task 2: Defeat enemies");
        CreateObjective("Task 3: Reach the goal");
    }

    void CreateObjective(string objectiveText)
    {
        GameObject objective = Instantiate(objectivePrefab, objectiveContainer);
        Text objectiveTextComponent = objective.GetComponentInChildren<Text>();
        objectiveTextComponent.text = objectiveText;
    }

    public void MarkObjectiveAsCompleted(GameObject objective)
    {
        Text objectiveTextComponent = objective.GetComponentInChildren<Text>();
        if (objectiveTextComponent != null)
        {
            // Add a strikethrough effect
            objectiveTextComponent.supportRichText = true;
            objectiveTextComponent.text = $"<s>{objectiveTextComponent.text}</s>";
        }
    }
}
