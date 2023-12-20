using System.Linq;

[System.Serializable]
public class CharacterMaster{
    public Character[] master;

    public Character GetById(int id){
        return master.Where(x => x.id == id).FirstOrDefault();
    }
}

[System.Serializable]
public class Character{
    public int id;
    public string name;
    public int hp;
    public int minDmg;
    public int maxDmg;
    public int addHpOnLvUp;
    public int addMinDmgOnLvUp;
    public int addMaxDmgOnLvUp;
    public string image;
}