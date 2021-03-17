using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModels : MonoBehaviour
{
    List<Transform> models;
    public int selectedPlayer;

    private void Awake()
    {
        models = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);
            model.gameObject.SetActive(i==0);
        }
    }

    public void EnableModel(Transform model)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var modelToggel = transform.GetChild(i);
            bool isTheRightOne = (modelToggel == model);
            modelToggel.gameObject.SetActive(isTheRightOne);
            if (isTheRightOne)
            {
                selectedPlayer = i;
            }
        }
    }
}
