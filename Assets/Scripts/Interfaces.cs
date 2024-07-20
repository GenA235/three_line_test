
public interface IMovable{
    public void Move();
    public float MoveSpeed { get; set; }
}

public interface IDamagable{
    public void TakeDamage(int amount);
    public float Health { get; set; }
}

public interface IDamager{
    public void Damage();
    public float DamagePower { get; set; }
}