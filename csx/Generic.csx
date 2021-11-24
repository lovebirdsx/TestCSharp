class BulletInfo {
    public string name = "BulletInfo";

    public virtual void OnTrigger() {
        Console.WriteLine("OnTrigger " + name);
    }
}

class BounceBulletInfo : BulletInfo {    
    public bool isBounced = false;

    public override void OnTrigger() {
        Console.WriteLine("OnTrigger isBounced " + isBounced.ToString());
    }
}

class Bullet<T> where T : BulletInfo {
    T info;

    public void Fire(T info) {
        this.info = info;
    }

    public void OnTrigger() {
        info.OnTrigger();
    }
}

class Foo<T> : Bullet<BulletInfo> where T : BulletInfo {

}

Bullet<BulletInfo> bullet1 = new Bullet<BulletInfo>();
Bullet<BounceBulletInfo> bullet2 = new Bullet<BounceBulletInfo>();

BulletInfo info1 = new BulletInfo();
BounceBulletInfo info2 = new BounceBulletInfo();

bullet1.Fire(info1);
bullet1.OnTrigger();
bullet2.Fire(info2);
bullet2.OnTrigger();
