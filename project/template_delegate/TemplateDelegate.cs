var eventManager = new EventMananger();

var ev1 = new PrintAction();
ev1.what = "Hello PrintAction!";

var ev2 = new AddAction();
ev2.a = 100;
ev2.b = 200;

var listenner = new EventListenner();
eventManager.Register(typeof(PrintAction), listenner.OnPrintAction);
eventManager.Register(typeof(AddAction), listenner.OnAddAction);
eventManager.FireEvent(ev1);
eventManager.FireEvent(ev2);

class AnimationAction {
    
}

class PrintAction : AnimationAction {
    public string? what;
}

class AddAction : AnimationAction {
    public int a;
    public int b;
}

class EventMananger {
    Dictionary<string, Action<AnimationAction>> callbacks = new Dictionary<string, Action<AnimationAction>>();
    public void Register(Type t, Action<AnimationAction> callback){
        callbacks.Add(t.Name, callback);
    }

    public void FireEvent(AnimationAction action) {
        var name = action.GetType().Name;
        if (callbacks.TryGetValue(name, out var callback)) {
            callback(action);
        } else {
            Console.WriteLine($"No action callback registed for {name}");
        }
    }
}

class EventListenner {
    public void OnPrintAction(AnimationAction action) {
        var printAction = action as PrintAction;
        Console.WriteLine(printAction?.what);
    }

    public void OnAddAction(AnimationAction action) {
        var addAction = action as AddAction;
        if (addAction != null) {
            Console.WriteLine($"{addAction.a} + {addAction.b} == {addAction.a + addAction.b}");
        }
    }
}
