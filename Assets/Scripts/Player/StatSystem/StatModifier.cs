public enum StatModifierMethod
{
    Flat = 100,
    Percentage = 200,
}

[System.Serializable]
public class StatModifier
{
    public CharacterStatHolder.Stat statToBoost;
    public float value;
    public StatModifierMethod method = StatModifierMethod.Flat;
    public readonly int order;

    public StatModifier(float t_value, StatModifierMethod t_class, int t_order)
    {
        value = t_value;
        method = t_class;
        order = t_order;
    }

    public StatModifier(float t_value, StatModifierMethod t_class) : this(t_value, t_class, (int)t_class) { }
}
