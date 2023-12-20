public class Consts
{
    private const string DamageFormat = "{0}~{1}";
    public static string GetDamageRangeText(int minDmg, int maxDmg) => "攻撃力:" + string.Format(DamageFormat, minDmg, maxDmg);
}