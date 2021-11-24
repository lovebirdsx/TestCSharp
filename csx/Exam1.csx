struct Pos {
    public float x;
    public float y;
}

struct Unit {
    public string name;
    public bool isMelee;
}

Pos GetInitUnitPos(int horIndex, int verIndex, int horMax, int verMax, Pos centerPos) {
    Pos pos = new Pos() {
        x = 30 * horIndex + centerPos.x,
        y = 40 * (verMax - verIndex) + centerPos.y
    };

    if (horMax % 2 == 0) {
        pos.x = pos.x - horMax / 2 * 30 + 15;
    } else {
        pos.x = pos.x - (horMax - 1) / 2 * 30;
    }

    if (verMax % 2 == 0) {
        pos.y = pos.y - verMax / 2 * 30 + 20;
    } else {
        pos.y = pos.y - (verMax - 1) / 2 * 40;
    }
    
    return pos;
}

Pos[] CalPosList(Unit[] unitsList, Pos pos) {
    Pos[] posList = new Pos[unitsList.Length];
    //按类型和角色进行分组  
    List<List<int>> meleeIndexList = new List<List<int>>();
    List<List<int>> rangeIndexList = new List<List<int>>();
    string meleeName = "";
    string rangeName = "";
    List<int> meleeUnits = new List<int>();
    List<int> rangeUnits = new List<int>();
    for (int i = 0; i < unitsList.Length; i++) {
        var unit = unitsList[i];
        if (unit.isMelee) {
            if (unit.name != meleeName) {
                meleeUnits = new List<int>();
                meleeIndexList.Add(meleeUnits);
                meleeName = unit.name;
            }
            meleeUnits.Add(i);
        } else {
            if (unit.name != rangeName) {
                rangeUnits = new List<int>();
                rangeIndexList.Add(rangeUnits);
                rangeName = unit.name;
            }
            rangeUnits.Add(i);
        }
    }

    //排队，每队8人，按队分组,先自左向右，再自右向左  
    List<List<int>> _meleeIndexList = new List<List<int>>();
    List<List<int>> _rangeIndexList = new List<List<int>>();
    List<int> _meleeUnits = new List<int>();
    List<int> _rangeUnits = new List<int>();
    _rangeIndexList.Add(_rangeUnits);
    _meleeIndexList.Add(_meleeUnits);
    int horIndex = 1;
    int index = 0;
    foreach (var melees in meleeIndexList) {
        foreach (var melee in melees) {
            if (index < 8) {
                if (horIndex % 2 == 1) {
                    _meleeUnits.Add(melee);
                } else {
                    _meleeUnits.Insert(0, melee);
                }

                index++;
            } else {
                _meleeUnits = new List<int>();
                _meleeIndexList.Add(_meleeUnits);
                index = 0;
                horIndex++;
            }
        }
    }
    horIndex = 1;
    index = 0;
    foreach (var ranges in rangeIndexList) {
        foreach (var range in ranges) {
            if (index < 8) {
                if (horIndex % 2 == 1) {
                    _rangeUnits.Add(range);
                } else {
                    _rangeUnits.Insert(0, range);
                }
                index++;
            } else {
                _rangeUnits = new List<int>();
                _rangeIndexList.Add(_rangeUnits);
                index = 0;
                horIndex++;
            }
        }
    }

    //确定中心对齐后的具体位置  
    int verMax = _meleeIndexList.Count + _rangeIndexList.Count;
    if (_meleeIndexList.Count > 0) {
        for (int i = _meleeIndexList.Count - 1; i >= 0; i--) {
            for (int j = 0; j < _meleeIndexList[i].Count; j++) {
                posList[_meleeIndexList[i][j]] = GetInitUnitPos(j, _meleeIndexList.Count - 1 - i,
                    _meleeIndexList[i].Count, verMax, pos);
            }
        }
    }
    if (_rangeIndexList.Count > 0) {
        for (int i = _rangeIndexList.Count - 1; i >= 0; i--) {
            for (int j = 0; j < _rangeIndexList[i].Count; j++) {
                posList[_rangeIndexList[i][j]] = GetInitUnitPos(j, _rangeIndexList.Count - 1 - i + _meleeIndexList.Count,
                    _rangeIndexList[i].Count, verMax, pos);
            }
        }
    }

    return posList;
}

