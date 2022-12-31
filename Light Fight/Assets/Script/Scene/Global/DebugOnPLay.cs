using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightFight.Global
{
    public class DebugOnPLay : MonoBehaviour
    {

        //DebugOnScreen
        #region static
        public static DebugOnPLay eventInstance;
        private static DebugOnPLay DebugOnScreen;

        public static DebugOnPLay instance
        {
            get
            {
                if (!DebugOnScreen)
                {
                    DebugOnScreen = FindObjectOfType(typeof(DebugOnPLay)) as DebugOnPLay;

                    if (!DebugOnScreen)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        DebugOnScreen.Init();
                    }
                }

                return DebugOnScreen;
            }
        }

        private void Awake()
        {
            if (eventInstance == null)
            {
                eventInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Init()
        {
        }

        #endregion

        [HideInInspector] public Vector2 _input;
        [HideInInspector] public String _inputD;
        [HideInInspector] public bool Fall;


        [SerializeField] private bool _debugging;
        private void OnGUI()
        {
                // for showing debugging information for mechanic move and grabber
                if (!_debugging) { return; }
                GUI.Label(new Rect(10, 10, 100, 200), "Debugging Info:");
                GUI.contentColor = Color.white;
                GUI.Label(new Rect(10, 40, 500, 200), $"input: {_inputD}");
                GUI.Label(new Rect(10, 55, 500, 200), $" direct input x: {_input.x}\n direct input y : {_input.y}");
                GUI.Label(new Rect(10, 90, 500, 200), $"fall : {Fall}");
        }
    }
    
}
