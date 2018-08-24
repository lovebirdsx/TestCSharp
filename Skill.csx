public abstract class SkillAction {
    public abstract bool Trigger(Role role, Vector3 dir);
}

public struct Vector3 {
    public float x;
    public float y;    
    public float z;
}

public class SkillAreaRender {

}

public abstract class SkillArea {
    SkillAction action;
    public abstract void Draw(SkillAreaRender render, Vector3 dir);
}

public class CastCondition {
    SkillAction action;

    public virtual bool CanCast(Role role, Vector3 dir) {
        return true;
    }
}

public class Skill {
    public class ActionSlot {
        public float waitTime;
        public SkillAction action;
    }
    public ActionSlot[] actions;        // 需要执行的动作序列
    public SkillArea skillArea;         // 技能提示范围
    public CastCondition castCondition; // 释放技能的条件
}

public class Role {
    SkillAreaRender skillAreaRender;
    bool isCasting;

    void Wait(float time) {

    }

    public bool CanCastSkill(Skill skill, Vector3 dir) {
        return skill.castCondition.CanCast(this, dir);
    }

    public void ShowSkillArea(Skill skill, Vector3 dir) {
        skill.skillArea.Draw(skillAreaRender, dir);
    }

    public void CastSkill(Skill skill, Vector3 dir) {
        isCasting = true;

        for (int i = 0; i < skill.actions.Length; i++) {
            var slot = skill.actions[i];
            if (slot.waitTime > 0) {
                Wait(slot.waitTime);
            }

            bool result = slot.action.Trigger(this, dir);
            if (!result) {
                break;
            }
        }

        isCasting = false;
    }
}
