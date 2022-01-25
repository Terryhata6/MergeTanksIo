using System.Collections.Generic;
using Polarith.AI.Move;
using UnityEngine;

public class AIMComponents : MonoBehaviour
{
    
    [SerializeField] private AIMContext _context;
    [SerializeField] private List<SeekDictionary> _seekers;

    public List<SeekDictionary> Seekers => _seekers;
    public AIMContext Context => _context;
}


