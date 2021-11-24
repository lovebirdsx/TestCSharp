
class Foo {
    public string name = "foo";
}

static class Bar {
    public static void Fun(bool value) {

    }

    public static void Fun(Foo value) {

    }
}


Foo foo = null;

Bar.Fun(foo);