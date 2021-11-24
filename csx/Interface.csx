interface IMovable {
    void Move(float x, float y);
}

interface IDamagable {
    void TakeDamage(float damage);
}

class GameObject {

}

class Wall : GameObject, IDamagable {
    float hp = 100;

    public void TakeDamage(float damage) {
        hp -= damage;
        Console.WriteLine("Wall TakeDamage");
    }
}

class Car : GameObject, IDamagable {
    float hp = 50;

    public void TakeDamage(float damage) {
        hp -= damage;
        Console.WriteLine("Car TakeDamage");
    }
}

class Grass : GameObject {

}

class Bullet {
    float damage = 10;

    public void OnCollider(GameObject obj) {
        IDamagable damagableObj = obj as IDamagable;
        if (damagableObj != null) {
            damagableObj.TakeDamage(damage);
        }
    }
}

Wall wall = new Wall();
Car car = new Car();
Grass grass = new Grass();
Bullet bullet = new Bullet();

bullet.OnCollider(car);
bullet.OnCollider(wall);
bullet.OnCollider(grass);
