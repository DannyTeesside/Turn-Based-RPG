using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {

        const string autoSaveFile = "autosave";
        const string defaultSaveFile = "save";

        //IEnumerator Start()
        //{
        //    yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
            
        //}

        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    Load();
            //}
            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    Save();
            //}
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
        public void AutoSave()
        {
            GetComponent<SavingSystem>().Save(autoSaveFile);
        }

        public void AutoLoad()
        {
            GetComponent<SavingSystem>().Load(autoSaveFile);
        }
    }
}
