using System.Collections.Generic;
using UnityEngine;

namespace PatternLogicScene.Pattern
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField] private GameObject patternBase;
        public List<Pattern> patterns;
        private GameObject pattern;

        [SerializeField] private int patternCount;

        private Vector3 nextPatternStartPoint;
        private int gatePatternCount => patterns[tag.CompareTo("Gate")].prefab.Count;

        private int emptyPatternCount => patterns[tag.CompareTo("Empty")].prefab.Count;

        private int gateStartPoint = 4;
        private int randomPatternIndex;
        private void Awake()
        {
            GeneratePattern();
        }


        private void GeneratePattern()
        {
            pattern = Instantiate(patterns[2]
                .prefab[Random.Range(0, emptyPatternCount)], nextPatternStartPoint, Quaternion.identity);
            pattern.transform.parent = patternBase.transform;
            nextPatternStartPoint = pattern.transform.GetChild(0).transform.position;

            for (int i = 0; i < patternCount; i++)
            {
                int randomPatternIndex = Random.Range(0, patterns.Count - 2);
                if (gateStartPoint==i)
                {
                    pattern = Instantiate(patterns[3]
                            .prefab[Random.Range(0, gatePatternCount)],
                        nextPatternStartPoint, Quaternion.identity);
                    pattern.transform.parent = patternBase.transform;
                    nextPatternStartPoint = pattern.transform.GetChild(0).transform.position;
                    
                    gateStartPoint = Random.Range(gateStartPoint+2, patterns.Count-1);
                }
                
                pattern = Instantiate(
                    patterns[randomPatternIndex].prefab[Random.Range(0, patterns[randomPatternIndex].prefab.Count)],
                    nextPatternStartPoint, Quaternion.identity);
                pattern.transform.parent = patternBase.transform;
                nextPatternStartPoint = pattern.transform.GetChild(0).transform.position;
            }

            pattern = Instantiate(patterns[4]
                .prefab[0], nextPatternStartPoint, Quaternion.identity);
            pattern.transform.parent = patternBase.transform;
            nextPatternStartPoint = pattern.transform.GetChild(0).transform.position;
        }
    }


    [System.Serializable]
    public class Pattern
    {
        public string tag;
        public List<GameObject> prefab;
    }
}