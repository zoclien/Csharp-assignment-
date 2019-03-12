using System;

public class massage
{
    public string sender;
    public string reader;
    public int time;
    public string data;
    public void setsender(string s)
    {
        this.sender = s;
    }
    public void setreader(string r)
    {
        this.reader = r;
    }
    public void setime(int t)
    {
        this.time = t;
    }
    public void setdata(string d)
    {
        this.data = d;
    }
    public void read()
    {
        Console.WriteLine("发送者：" + this.sender + "接收者：" + this.reader + "日期：" + this.time + "内容：" + this.data);
    }
	public massage clonemassage()
	{
        massage m = new massage();
        m.time = this.time;
        m.reader = this.reader;
        m.sender = this.sender;
        m.data = this.data;
        return m;
	}
}
