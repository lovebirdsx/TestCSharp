public class Role {
    public event EventHandler AttackEvent;

    public void Attack() {
        Console.WriteLine("Role.Attack()");
        AttackEvent(this, EventArgs.Empty);
    }
}

static Role role = new Role();

class GameObject {
    public string name;

    void OnAttack(object sender, EventArgs args) {
        Console.WriteLine("{0} OnAttack", name);
    }

    public void Start() {
        role.AttackEvent += OnAttack;
    }

    public void End() {
        role.AttackEvent -= OnAttack;
    }
}

class Game {
    List<GameObject> gameObjects = new List<GameObject>();

    public void AddGameObject(GameObject obj) {
        gameObjects.Add(obj);
    }

    public void Start() {
        foreach (var obj in gameObjects) {
            obj.Start();
        }
    }

    public void End() {
        foreach (var obj in gameObjects) {
            obj.End();
        }
    }
}

Game game = new Game();
game.AddGameObject(new GameObject() {name = "Foo"});
game.AddGameObject(new GameObject() {name = "Bar"});
game.Start();
role.Attack();
role.Attack();
game.End();