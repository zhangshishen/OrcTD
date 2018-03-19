public class ArmorCalc{
    float coefficient;
    public static float[,] f = new float[4,4]{ { 0.5f, 0.4f, 0.8f, 0.9f },
        {0.75f,0.70f,0.80f,0.9f},
        {0.7f,0.8f,1.0f,1.0f},
        {1.0f,1.0f,1.0f,1.0f}};
    public static float GetCoefficient(AttackType atttype,ArmorType armtype){
        switch(atttype){
            case AttackType.AROW:
                return ArmorCalc.setCoef(armtype, f,0);
            case AttackType.COMMON:
                return ArmorCalc.setCoef(armtype, f, 1);
            case AttackType.MAGIC:
                return ArmorCalc.setCoef(armtype, f, 2);
            case AttackType.PURE:
                return 1;
        }

        return 0;
    }
    public static float setCoef(ArmorType armtype,float[,] f,int i){
        return f[i,(int)armtype];
    }
}
