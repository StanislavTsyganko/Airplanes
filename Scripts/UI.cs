using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Класс для пользовательского интерфейса
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
        // Инициализация начальных значений
        speedSlider.value = 1.0f;  // Начальный множитель скорости
        speedSlider.onValueChanged.AddListener(OnSpeedChanged);

        // Настройка кнопок для изменения количества самолетов
        increaseAirplanesButton.onClick.AddListener(IncreaseAirplanes);
        decreaseAirplanesButton.onClick.AddListener(DecreaseAirplanes);
    }

    // Обработчик изменения скорости
    void OnSpeedChanged(float value)
    {
        airplaneManager.ChangeSpeed(value);
        speedText.text = "Множитель скорости: " + value.ToString("N3");
    }

    // Увеличение количества самолетов
    void IncreaseAirplanes()
    {
        if (airplaneManager.NumberOfAirplanes > 9)
            return;
        airplaneManager.SetNumberOfAirplanes(airplaneManager.NumberOfAirplanes + 1);
        airplanesCountText.text = "Самолётов: " + airplaneManager.NumberOfAirplanes;
    }

    // Уменьшение количества самолетов
    void DecreaseAirplanes()
    {
        if (airplaneManager.NumberOfAirplanes < 3)
            return;
        airplaneManager.SetNumberOfAirplanes(airplaneManager.NumberOfAirplanes - 1);
        airplanesCountText.text = "Самолётов: " + airplaneManager.NumberOfAirplanes;
    }

}