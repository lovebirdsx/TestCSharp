delegate void PrintDelegate(int num);

void Foo(int num) {
    Console.WriteLine("Foo({0}) = {1}", num, num);
}

void Bar(int num) {
    Console.WriteLine("Bar({0}) = {1}", num, num * num);
}

PrintDelegate print = Foo;
print(2);
print = Bar;
print(2);

PrintDelegate print2 = Foo;
print2 += Bar;
print2(2);
print2 -= Bar;
print2(2);

delegate bool ConditionHandler();
ConditionHandler conditions;

bool ConditionA() {
    return true;
}

bool ConditionB() {
    return false;
}

if (conditions != null)
    conditions.Invoke();

conditions += ConditionA;
conditions += ConditionB;

// conditions();
foreach(ConditionHandler c in conditions.GetInvocationList()) {
    Console.WriteLine("{0} = {1}", c.Method.Name, c());
}