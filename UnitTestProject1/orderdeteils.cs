using System;

public class orderdeteils
{
    public int[] num = new int[100];
    public string[] goodslist = new string[100];
    public int nums;
    public override bool Equals(object  s)
    {
        var d = s as orderdeteils;
        return this.nums != 0 && this.num != d.num && this.goodslist != d.goodslist;
    }
    public override int GetHashCode()
    {
        int  hashcode = 1522631281;
        hashcode=hashcode*-1521134295+nums.GetHashCode();
        hashcode = hashcode * -1521134295 + num.GetHashCode();
        hashcode = hashcode * -1521134295 + goodslist.GetHashCode();
        return  hashcode;
        //turn base.GetHashCode();
    }
    public override string ToString()
    {
        string a = "";
        for(int i=0;i<nums;i++)
        {
            a = a+"//"+goodslist[i] + "/" + num[i];
        }
        return a;
    }
    public orderdeteils()
    {
        string s;
        Console.WriteLine("goods numbers");
        s = Console.ReadLine();
        this.nums = int.Parse(s);
        int i;
        for (i = 0; i < this.nums; i++)
        {

            Console.WriteLine("goods" + i + "name");
            goodslist[i] = Console.ReadLine();
            Console.WriteLine("goods" + i + "number");
            s = Console.ReadLine();
            num[i] = int.Parse(s);

        }
    }
}
