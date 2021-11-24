void MyAssert(bool result) {
    if (!result) {
        Console.WriteLine("Faild");
    }
}

public enum OrthogonalState {
    State1,
    State2,
    State3,
    State4,
    State5,
}

int orthogonalStates;

public void SetOrthogonalState(OrthogonalState state, bool value) {
    if (value) {
        orthogonalStates |= (1 << (int) state);
    } else {
        orthogonalStates ^= (1 << (int) state);
    }
}

public bool GetOrthogonalState(OrthogonalState state) {
    return (orthogonalStates & (1 << (int) state)) > 0;
}

SetOrthogonalState(OrthogonalState.State2, true);
SetOrthogonalState(OrthogonalState.State3, true);

MyAssert(!GetOrthogonalState(OrthogonalState.State1));
MyAssert(GetOrthogonalState(OrthogonalState.State2));
MyAssert(GetOrthogonalState(OrthogonalState.State3));
SetOrthogonalState(OrthogonalState.State3, false);
MyAssert(!GetOrthogonalState(OrthogonalState.State1));
MyAssert(GetOrthogonalState(OrthogonalState.State2));
MyAssert(!GetOrthogonalState(OrthogonalState.State3));

Console.WriteLine("Succeed!");