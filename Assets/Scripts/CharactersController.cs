using System.Collections.Generic;
using UnityEngine;

namespace ARPlayer
{
    public class CharactersController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _characters;
        [SerializeField] private Transform _parent;

        private int _currentCharacterId;
        private GameObject _currentObject;

        public void SelectNext()
        {
            Destroy(_currentObject);
            Increase();
            InstantiateCharacter();
        }

        public void SelectPrev()
        {
            Destroy(_currentObject);
            Decrease();
            InstantiateCharacter();
        }

        private void InstantiateCharacter()
        {
            _currentObject = Instantiate(_characters[_currentCharacterId], _parent);
        }

        private void Increase()
        {
            _currentCharacterId++;
            if (_currentCharacterId >= _characters.Count - 1)
                _currentCharacterId = 0;
        }

        private void Decrease()
        {
            _currentCharacterId--;
            if (_currentCharacterId < 0)
                _currentCharacterId = _characters.Count - 1;
        }
    }
}