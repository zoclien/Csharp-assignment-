using System;
using System.xml;
using System.Collections.Generic;
using System.Linq;
public class TVname
{
    public TVf getname()
    {
        XmlDocument name = new XmlDocument();
        name.Load(@"\config.Xml");
        XmlNode x = name.SelectSingleNode("classname");
        if (x.Value == "hisenceTVf")
            return new hisenceTVf();

        return new haierTVf();
        
    }
}
