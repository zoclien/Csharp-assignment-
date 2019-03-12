using System;

public class hisenceTVf :TVf
{
	public TV produceTV()
	{
        Console.WriteLine("海信电视机生产");
        return new hisenceTV();
	}
}
