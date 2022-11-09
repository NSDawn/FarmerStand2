using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class ChangeCameraButton : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public List<Camera> Cameras;
    public Light ToggleLight;
    public List<float> Intensity;

    // create frame and button variables 
    private VisualElement frame;
    private Button buttonCamera;
    private Button buttonLight;

    // This function is called when the object becomes enabled and active.
    void OnEnable() { 
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        
        frame = rootVisualElement.Q<VisualElement>("VisualElement");
    
        // get the button, which is nested in the frame
        buttonCamera = frame.Q<Button>("Button");
        // create event listener that calls ChangeCamera() when pressed
        buttonCamera.RegisterCallback<ClickEvent>(ev => ChangeCamera());

         // get the button, which is nested in the frame
        buttonLight = frame.Q<Button>("ButtonLight");
        // create event listener that calls ChangeCamera() when pressed
        buttonLight.RegisterCallback<ClickEvent>(ev => ChangeLight());

        
    }

    // initialize click count
    int click = 0;
    private void ChangeCamera(){
        EnableCamera(click);
        click++;
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(click > 3){
            click = 0;
        }
    }

    private void EnableCamera(int n) {
        // disable each of the cameras
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras.ForEach(cam => cam.depth = 0);

        // enable the selected camera
        Cameras[n].enabled = true;
        Cameras[n].depth = 1;

    }
    
    int clickLight = 0;
    private void ChangeLight() {
        EnableLight(clickLight);
        clickLight++;
        // reset counter so it is not out of bounds (only have 3 light settings)
        if(clickLight > 2) {
            clickLight = 0;
        }
    }
    
    private void EnableLight(int n) {
        ToggleLight.intensity = Intensity[n];
        Debug.Log(Intensity[n]);
    }

    
    
}
