using System;

public class haierTVf:TVf
{
	public TV produceTV()
	{
        Console.WriteLine("海尔电视机生产");
        return new haierTV();
	}
}
