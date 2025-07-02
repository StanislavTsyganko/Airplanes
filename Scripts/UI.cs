using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ����� ��� ����������������� ����������
public class UI : MonoBehaviour
{
    public AirplaneManager airplaneManager;
    public Slider speedSlider;
    public Text speedText;
    public Button increaseAirplanesButton;
    public Button decreaseAirplanesButton;
    public Text airplanesCountText;

    void Start()
    {
        // ������������� ��������� ��������
        speedSlider.value = 1.0f;  // ��������� ��������� ��������
        speedSlider.onValueChanged.AddListener(OnSpeedChanged);

        // ��������� ������ ��� ��������� ���������� ���������
        increaseAirplanesButton.onClick.AddListener(IncreaseAirplanes);
        decreaseAirplanesButton.onClick.AddListener(DecreaseAirplanes);
    }

    // ���������� ��������� ��������
    void OnSpeedChanged(float value)
    {
        airplaneManager.ChangeSpeed(value);
        speedText.text = "��������� ��������: " + value.ToString("N3");
    }

    // ���������� ���������� ���������
    void IncreaseAirplanes()
    {
        if (airplaneManager.NumberOfAirplanes > 9)
            return;
        airplaneManager.SetNumberOfAirplanes(airplaneManager.NumberOfAirplanes + 1);
        airplanesCountText.text = "��������: " + airplaneManager.NumberOfAirplanes;
    }

    // ���������� ���������� ���������
    void DecreaseAirplanes()
    {
        if (airplaneManager.NumberOfAirplanes < 3)
            return;
        airplaneManager.SetNumberOfAirplanes(airplaneManager.NumberOfAirplanes - 1);
        airplanesCountText.text = "��������: " + airplaneManager.NumberOfAirplanes;
    }

}