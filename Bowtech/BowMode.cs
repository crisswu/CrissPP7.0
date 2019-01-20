using System;
using System.Collections.Generic;
using System.Text;

namespace Bowtech
{
    public class BowMode
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        string fatherID;

        public string FatherID
        {
            get { return fatherID; }
            set { fatherID = value; }
        }
    }
}
