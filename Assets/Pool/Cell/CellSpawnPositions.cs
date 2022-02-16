using System.Collections.Generic;

using UnityEngine;

public class CellSpawnPositions
{
     private readonly List<Vector2> _spawnPositions;
     
     private readonly Rect _gameFieldRect;
     private readonly Transform _prefabTransform;
     private readonly float _offset;
     
     public CellSpawnPositions(Transform gameFieldTransform, float offset, Transform prefabTransform)
     {
          var fieldSize = new Vector2(gameFieldTransform.localScale.x, gameFieldTransform.localScale.y);
          var gameFieldPosition = gameFieldTransform.position;

          _gameFieldRect = new Rect(gameFieldPosition, fieldSize);
          
          _offset = offset;
          _prefabTransform = prefabTransform;

          _spawnPositions = new List<Vector2>();
          SetSpawnPositions();
     }

     public IReadOnlyList<Vector2> SpawnPositions => _spawnPositions;
     
     private void SetSpawnPositions()
     {
          for (var x = GetStartPosition().x; x < GetEndPosition().x; x += _offset)
          {
               for (var y = GetStartPosition().y; y < GetEndPosition().y; y += _offset)
               {
                    var spawnPosition = new Vector2(x, y) + (Vector2)_prefabTransform.localScale / 2;
                    _spawnPositions.Add(spawnPosition);
               }
          }
     }
     
     private Vector2 GetStartPosition()
     {
          var startXPosition = _gameFieldRect.position.x - _gameFieldRect.size.x / 2;
          var startYPosition = _gameFieldRect.position.y - _gameFieldRect.size.y / 2;

          return new Vector2(startXPosition, startYPosition);
     }
     private Vector2 GetEndPosition()
     {
          var endXPosition = _gameFieldRect.position.x + _gameFieldRect.size.x / 2;
          var endYPosition = _gameFieldRect.position.y + _gameFieldRect.size.y / 2;

          return new Vector2(endXPosition, endYPosition);
     }
}