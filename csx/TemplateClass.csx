class Bullet {
    public string name = "Bullet";
}

class BulletA : Bullet {
    public BulletA() {
        name = "BulletA";
    }
}

class BulletB : Bullet {
    public BulletB() {
        name = "BulletB";
    }
}

class Action {
    public int offset;
}

class ShootAction<T> : Action where T : Bullet {

    public virtual void Shoot() {
        Console.WriteLine("ShootAction<T>");
    }
}

class ShootActionA : ShootAction<BulletA> {

    public ShootActionA() {
        offset = 1;
    }

    public override void Shoot() {
        Console.WriteLine("ShootActionA offset = {0}", offset);
    }
}

class ShootActionB : ShootAction<BulletA> {

    public ShootActionB() {
        offset = 2;
    }

    public override void Shoot() {
        Console.WriteLine("ShootActionB offset = {0}", offset);
    }
}

var sa = new ShootActionA();
var sb = new ShootActionB();

sa.Shoot();
sb.Shoot();

Action action = (Action)sa;
Console.WriteLine(action.offset);

action = (Action)sb;
Console.WriteLine(action.offset);
