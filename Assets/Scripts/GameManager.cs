using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<AudioClip> otherClips;
    public List<AudioClip> whaleGroup, seagullGroup, seaLionGroup;
    public List<AudioClip> whaleButtonList, seagullButtonList, seaLionButtonList;
    public List<Transform> groupList;
    public List<Vector3Int> whaleGroupCoordinates, seagullGroupCoordinates, seaLionGroupCoordinates;
    public float timer2;
    private float timer;
    private int reloadCount;
    
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        var index = Random.Range(0, whaleGroupCoordinates.Count);
        CreateGroup(whaleGroupCoordinates,whaleButtonList,whaleGroup,index);
        whaleGroupCoordinates.Remove(whaleGroupCoordinates[index]);
        var index2 = Random.Range(0, whaleGroupCoordinates.Count);
        CreateGroup(seagullGroupCoordinates,seagullButtonList,seagullGroup,index2);
        seagullGroupCoordinates.Remove(seagullGroupCoordinates[index2]);
        var index3 = Random.Range(0, whaleGroupCoordinates.Count);
        CreateGroup(seaLionGroupCoordinates,seaLionButtonList,seaLionGroup,index3);
        seaLionGroupCoordinates.Remove(seaLionGroupCoordinates[index3]);
        //var shuffledList = groupList.OrderBy(x => Random.value).ToList();
        SelectGroup(groupList);
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Period))
        {
            reloadCount++;
            if (reloadCount >2)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Init();
            }
        }

        if (timer > 500)
        {
            SceneManager.LoadScene(0);
        }

        if (timer2 > 120)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CreateGroup(List<Vector3Int> coordinates,List<AudioClip> buttons,List<AudioClip> group,int index)
    {
        var x = coordinates[index].x;
        var y = coordinates[index].y;
        var z = coordinates[index].z;
        CreateButtonLists(x,y,z,buttons,group);
    }

    private void SelectGroup(List<Transform> groups)
    {
        
        for (var i = 0; i < groups.Count; i++)
        {
            switch(i)
            {
                case 0:
                    for (int j = 0; j < groups[i].childCount; j++)
                    {
                        groups[i].GetChild(j).GetComponent<PressKeyHandler>().list = whaleButtonList;
                    }

                    break;
                case 1:
                    for (int j = 0; j < groups[i].childCount; j++)
                    {
                        groups[i].GetChild(j).GetComponent<PressKeyHandler>().list = seagullButtonList;
                    }

                    break;
                case 2:
                    for (int j = 0; j < groups[i].childCount; j++)
                    {
                        groups[i].GetChild(j).GetComponent<PressKeyHandler>().list = seaLionButtonList;
                    }

                    break;

                    
            }
        }
        
    }


 

    private void CreateButtonLists(int x, int y, int z, List<AudioClip> buttons, List<AudioClip> group)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i]=group[1];
        }
        for (var i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                {
                    buttons.Insert(x, group[0]);
                    buttons.RemoveAt(x + 1);

                    break;
                }
                case 1:
                {
                    buttons.Insert(y, group[0]);
                    buttons.RemoveAt(y + 1);

                    break;
                }
                case 2:
                {
                    buttons.Insert(z, group[0]);
                    buttons.RemoveAt(z + 1);
                    break;
                }
            }
        }

         // ShuffleList(buttons, group);

         for (var i = 0; i < buttons.Count; i++)
         {
             if (buttons[i] != null) continue;
             buttons[i] = group[1];
         }
    }

    // private void ShuffleList(List<AudioClip> buttons, List<AudioClip> group)
    // {
    //     List<AudioClip> remainingElements =
    //         new List<AudioClip>(group.GetRange(1,
    //             group.Count - 1)); // Get the remaining audio clips of the group (excluding the first element)
    //
    //     List<int> availableIndices = new List<int>(); // List to store available button indices
    //
    //     for (int i = 0; i < buttons.Count; i++)
    //     {
    //         if (buttons[i] == null)
    //         {
    //             availableIndices.Add(i);
    //         }
    //     }
    //
    //     for (int i = 0; i < remainingElements.Count; i++)
    //     {
    //         int occurrences = 0;
    //         int elementCount = 3; // Number of times each element should be represented
    //
    //         while (occurrences < elementCount)
    //         {
    //             int attempts = 0;
    //             int index = Random.Range(0, availableIndices.Count);
    //             int selectedIndex = availableIndices[index];
    //
    //             while (!IsValidPlacement(buttons, selectedIndex, remainingElements[i]) && attempts < availableIndices.Count)
    //             {
    //                 index = (index + 1) % availableIndices.Count;
    //                 selectedIndex = availableIndices[index];
    //                 attempts++;
    //             }
    //
    //             if (IsValidPlacement(buttons, selectedIndex, remainingElements[i]))
    //             {
    //                 buttons[selectedIndex] = remainingElements[i];
    //                 availableIndices.RemoveAt(index);
    //                 occurrences++;
    //             }
    //             else
    //             {
    //                 // No suitable spot found within the available indices, place the element in the first available free spot
    //                 for (int j = 0; j < buttons.Count; j++)
    //                 {
    //                     if (buttons[j] == null)
    //                     {
    //                         buttons[j] = remainingElements[i];
    //                         occurrences++;
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }

    bool IsValidPlacement(List<AudioClip> buttons, int index, AudioClip element)
    {
        if (index > 0 && buttons[index - 1] == element)
        {
            return false;
        }

        if (index < buttons.Count - 1 && buttons[index + 1] == element)
        {
            return false;
        }

        return true;
    }
   

   

    // private void CreateGroups()
    // {
    //    
    //     var tempList = new List<AudioClip>(otherClips);
    //     FillLists(tempList,whaleGroup);
    //     FillLists(tempList,seagullGroup);
    //     FillLists(tempList,seaLionGroup);
    //
    // }

    // private void FillLists(List<AudioClip> tempList,List<AudioClip> fillList)
    // {
    //     for (var i = 0; i < 3; i++)
    //     {
    //         var index = Random.Range(0, tempList.Count);
    //         fillList.Add(tempList[index]);
    //         tempList.RemoveAt(index);
    //     }
    // }

    
  
}
