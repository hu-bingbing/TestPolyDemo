using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

    [Range(10,15)]
    public int BirthCount = 10;
	public GameObject Ground;
    public GameObject BirthPoint;

	private GameObject LastMap = null;

    private List<Vector3> m_NoOccupyList = new List<Vector3>();
    private List<Vector3> m_OccupyList = new List<Vector3>();

	public void Start () {
		UI_GenerateMap();
	}


	public void UI_GenerateMap () {
		if (LastMap) {
			Destroy(LastMap);
		}
        m_NoOccupyList.Clear();
        m_OccupyList.Clear();
        var map = new MoenenGames.FleckMapGenerator.FleckMap()
        {
            Bump = 0.1f,
		};

        map.Generate(64, 64);
		LastMap = map.SpawnToScene(null, Ground);
        for (int i = 0; i < map.AllGroundPointList.Count; i++)
        {
            m_NoOccupyList.Add(map.AllGroundPointList[i]);
        }
        for (int i = 0; i < BirthCount; i++)
        {
            int randomIndex = Random.Range(0, m_NoOccupyList.Count);
            Vector3 point = m_NoOccupyList[randomIndex];
            GameObject g = Object.Instantiate(BirthPoint);
            g.name = "Birth" + i;
            g.transform.SetParent(map.RootPoint.transform);
            g.transform.position = new Vector3(point.x, point.y + 1/2.0f, point.z);
            g.transform.localRotation = Quaternion.identity;
            g.transform.localScale = Vector3.one;
            m_NoOccupyList.Remove(point);
            m_OccupyList.Add(point);
        }
    }


}
