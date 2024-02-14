using System.Collections.Generic;



namespace Entity.Enemy
{
    public class EnemyStorage
    {
        public List<IEntity> Enemies { get; } = new();

        public void AddEnemy(params IEntity[] enemies)
        {
            foreach (var enemy in enemies)
            {
                Enemies.Add(enemy);
            }
        }

        public bool HasEnemy(IEntity enemy)
        {
            if(!Enemies.Contains(enemy))
                return false;
            return true;
        }
        
        public int GetEnemiesCount()
        {
            return Enemies.Count;
        }
        
        public void RemoveEnemy(IEntity enemy)
        {
            if(!HasEnemy(enemy))
                return;
            
            Enemies.Remove(enemy);
        }
        
        public void RemoveEnemy(params IEntity[] enemies)
        {
            foreach (var enemy in enemies)
            {
                if(!HasEnemy(enemy))
                    return;
            
                Enemies.Remove(enemy);
            }
        }
    }
}