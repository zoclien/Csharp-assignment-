using System;

public class orders:IComparable
{
    public int   number;
    string client;
    orderdeteils det = new orderdeteils();
    public int CompareTo(object s)
    {
        return number - (s as orders).number;
    }
    public override bool Equals(object obj)
    {
        var d = obj as orders;
        return this.det.Equals(d.det) && number == d.number && client == d.client;
      // return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        int hashcode = 1522631281;
        hashcode = hashcode * -1521134295 + number.GetHashCode();
        hashcode = hashcode * -1521134295 + client.GetHashCode();
        hashcode = hashcode * -1521134295 + det.GetHashCode();
        return hashcode;
        // return base.GetHashCode();
    }
    public override string ToString()
    {
        return "name:" + client + "oederid:" + number + det.ToString();
    }
    public void display()
    {
        Console.WriteLine("order number" + this.number + "client name" + this.client);
    }
    public orders()
    {
        Console.WriteLine("client");
        this.client = Console.ReadLine();
        Console.WriteLine("number");
        string k = Console.ReadLine();
        this.number = int.Parse(k);
        this.det = new orderdeteils();
    }
}
