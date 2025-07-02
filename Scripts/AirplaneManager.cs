using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Класс для управления самолетами
public class AirplaneManager : MonoBehaviour
{
    public GameObject AirplanePrefab;
    public GameObject FigterJetPrefab;
    public int NumberOfAirplanes;
    public int MinSpeed, MaxSpeed;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _upPoint;
    [SerializeField] private Transform _downPoint;
    [SerializeField] private Transform[] _spawnPoints;
    float speedMultiplier=1;



    private List<Aircraft> airplanes;

    public static object Instance { get; internal set; }

    void Start()
    {
        airplanes = new List<Aircraft>();
        for (int i = 0; i < NumberOfAirplanes; i++)
        {
            CreateAirplane();
        }
    }

    void Update()
    {
        foreach (Aircraft airplane in airplanes.ToArray())
        {
            if (airplane != null)
            {
                airplane.Move(speedMultiplier);
                if (airplane.transform.position.x > _rightPoint.position.x && airplane.Direction.x > 0)
                {
                    airplane.transform.position = new Vector3(_leftPoint.position.x, airplane.transform.position.y, 0);
                }
                if (airplane.transform.position.x < _leftPoint.position.x && airplane.Direction.x < 0)
                {
                    airplane.transform.position = new Vector3(_rightPoint.position.x, airplane.transform.position.y, 0);
                }
                if (airplane.transform.position.y < _downPoint.position.y)
                {
                    airplane.transform.position = new Vector3(airplane.transform.position.x, _upPoint.position.y, 0);
                }
                if (airplane.transform.position.y > _upPoint.position.y)
                {
                    airplane.transform.position = new Vector3(airplane.transform.position.x, _downPoint.position.y, 0);
                }
            }
            else
                airplanes.Remove(airplane);
            if(airplanes.Count<NumberOfAirplanes)
                CreateAirplane();
        }
    }

    public void CreateAirplane()
    {
        int num = UnityEngine.Random.Range(0, 7);
        Transform randomSpawnPoint = _spawnPoints[num];
        Vector3 position = new Vector3(randomSpawnPoint.transform.position.x + UnityEngine.Random.Range(-10f, 10f), randomSpawnPoint.transform.position.y + UnityEngine.Random.Range(-10f, 10f), 0);
        int airplaneType = UnityEngine.Random.Range(0, 2);
        Aircraft aircraft;
        Vector3 Direction = new Vector3((float)Mathf.Sign(position.x), UnityEngine.Random.Range(-0.3f, 0.3f), 0).normalized;
        float Speed = (float)UnityEngine.Random.Range(MinSpeed, MaxSpeed);
        if (airplaneType == 0)
        {
            GameObject airplaneObject = Instantiate(AirplanePrefab, position, Quaternion.identity);
            aircraft = airplaneObject.GetComponent<Airplane>();
            aircraft.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            GameObject airplaneObject = Instantiate(FigterJetPrefab, position, Quaternion.identity);
            aircraft = airplaneObject.GetComponent<FighterJet>();
            aircraft.transform.localScale= new Vector3(0.1f, 0.1f, 0.1f);
        }
        if(Direction.x<0)
        {
            aircraft.transform.localScale = new Vector3(-aircraft.transform.localScale.x, aircraft.transform.localScale.y, aircraft.transform.localScale.z);
        }
        aircraft.Speed= Speed;
        aircraft.Direction = Direction;
        aircraft.Position = position;
        airplanes.Add(aircraft);
    }

    public void ChangeSpeed(float speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }

    public void SetNumberOfAirplanes(int number)
    {
        // логика для изменения количества самолетов
        NumberOfAirplanes = number; // Update NumberOfAirplanes
        while (airplanes.Count < NumberOfAirplanes)
        {
            CreateAirplane();
        }
        while (airplanes.Count > NumberOfAirplanes)
        {
            Destroy(airplanes[airplanes.Count - 1].gameObject);
            airplanes.RemoveAt(airplanes.Count - 1);
        }
    }


}
