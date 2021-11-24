class Bullet {
    public string name;
}

class BulletA :Bullet {
    public BulletA() {
        name = "BulletA";
    }
}

class BulletB : Bullet {
    public BulletB() {
        name = "BulletB";
    }
}

abstract class ShootAction {
    public abstract Bullet Bullet { get; }
}

class ShootActionA {
    BulletA bullet = new BulletA();

    public Bullet Bullet { get { return bullet; } }
}

class ShootActionB {
    BulletB bullet = new BulletB();

    public Bullet Bullet { get { return bullet; } }
}

var sa = new ShootActionA();
var sb = new ShootActionB();
Console.WriteLine(sa.Bullet.name);
Console.WriteLine(sb.Bullet.name);