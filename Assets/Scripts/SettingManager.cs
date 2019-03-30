using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {
    public Slider projectorHeightSlider;
    public Slider distanceSlider;
    public Slider spotAngleSlider;
    public InputField distanceInput;
    public InputField diameterInput;
    public Button setButton;
    public Slider sensitiveSlider;
    public Toggle enableHandToggle;
    public Button resetButton;
    public Button applyButton;

    public Text projectorHeightText;
    public Text distanceText;
    public Text spotAngleText;
    public Text sensitiveText;

    public GameObject LeapMotion;
    public Light spotlight;
    public Camera mainCamera;
    public GameObject handModelLeft;
    public GameObject handModelRight;

    public GameSettings gameSettings;

    void OnEnable() {
        gameSettings = new GameSettings();

        projectorHeightText.text = (projectorHeightSlider.value * 10).ToString("0");
        distanceText.text = (distanceSlider.value * 10).ToString("0");
        spotAngleText.text = spotAngleSlider.value.ToString("0.0");
        sensitiveText.text = sensitiveSlider.value.ToString("0");

        projectorHeightSlider.onValueChanged.AddListener(delegate { OnProjectorHeightChange(); });
        distanceSlider.onValueChanged.AddListener(delegate { OnDistanceChange(); });
        spotAngleSlider.onValueChanged.AddListener(delegate { OnSpotAngleChange(); });
        setButton.onClick.AddListener(delegate { OnSetButtonClick(); });
        sensitiveSlider.onValueChanged.AddListener(delegate { OnSensitiveChange(); });
        enableHandToggle.onValueChanged.AddListener(delegate { OnEnableHandToggle(); });
        resetButton.onClick.AddListener(delegate { OnResetButtonClick(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
        LoadSettings();
    }

    public void OnProjectorHeightChange() {
        projectorHeightText.text = (projectorHeightSlider.value * 10).ToString("0");

        LeapMotion.transform.position = new Vector3(0, -projectorHeightSlider.value + 0.6F, -1.9F);
    }

    public void OnDistanceChange() {
        distanceText.text = (distanceSlider.value * 10).ToString("0");

        spotlight.transform.position = new Vector3(0, 0, -distanceSlider.value);
        spotlight.range = (distanceSlider.value - 9) * 1.6F + 30;
        mainCamera.fieldOfView = Mathf.Atan(Mathf.Tan(spotAngleSlider.value / 2 * Mathf.Deg2Rad) * (distanceSlider.value  + 8) * 0.375F) * Mathf.Rad2Deg * 2;
    }

    public void OnSpotAngleChange() {
        spotAngleText.text = spotAngleSlider.value.ToString("0.0");

        spotlight.spotAngle = spotAngleSlider.value;
        mainCamera.fieldOfView = Mathf.Atan(Mathf.Tan(spotAngleSlider.value / 2 * Mathf.Deg2Rad) * (distanceSlider.value + 8) * 0.375F) * Mathf.Rad2Deg * 2;
    }

    public void OnSetButtonClick() {
        spotAngleSlider.value = Mathf.Atan(float.Parse(diameterInput.text) / float.Parse(distanceInput.text) / 2) * Mathf.Rad2Deg * 2;
        diameterInput.text = "";
        distanceInput.text = "";
    }

    public void OnSensitiveChange() {
        sensitiveText.text = sensitiveSlider.value.ToString("0");

        MouseRotate.torque = sensitiveSlider.value;
    }

    public void OnEnableHandToggle() {
        handModelLeft.active = enableHandToggle.isOn;
        handModelRight.active = enableHandToggle.isOn;
    }

    public void OnResetButtonClick() {
        projectorHeightSlider.value = 2;
        distanceSlider.value = 9;
        spotAngleSlider.value = 30;
        sensitiveSlider.value = 65;
    }

    public void OnApplyButtonClick() {
        SaveSettings();
    }

    public void SaveSettings() {
        gameSettings.projectorHeight = projectorHeightSlider.value;
        gameSettings.distance = distanceSlider.value;
        gameSettings.spotAngle = spotAngleSlider.value;
        gameSettings.sensitive = sensitiveSlider.value;

        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", jsonData);
        
    }

    public void LoadSettings() {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/settings.json"));
        projectorHeightSlider.value = gameSettings.projectorHeight;
        distanceSlider.value = gameSettings.distance;
        spotAngleSlider.value = gameSettings.spotAngle;
        sensitiveSlider.value = gameSettings.sensitive;


    }
}
