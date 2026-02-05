public enum Direction 
{ 
    Up, 
    Down, 
    Left, 
    Right 
}

public enum TimeSkillType
{
    None,
    ChronoShift,    // 감속/가속
    TimeAnchor,     // 현재 위치 저장/복귀
    Rewind,         // 대상 시간 역행
    EchoClone       // 과거의 잔상 소환
}

public enum EnemyType
{
    Normal,
    Elite,
    Boss
}
