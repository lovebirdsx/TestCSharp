public abstract class Entity {
    
}

public class Player : Entity, IDamageable
{
    public bool IsDead => throw new NotImplementedException();

    public event DiedHandler Died;

    public void TakeDamage(Entity entity, float damage)
    {
        throw new NotImplementedException();
    }
}

public delegate void DiedHandler(Entity killer);

public interface IDamageable {
    event DiedHandler Died;
    void TakeDamage(Entity entity, float damage);
    bool IsDead { get; }
}

public interface IDigable {
     void TakeDig(Entity entity, float damage);
}