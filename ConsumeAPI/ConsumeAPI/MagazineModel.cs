using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeAPI
{
    public class MagazineModel
    {

    }
    public class tokenModel
    {
        public bool success { get; set; }
        public string token { get; set; }
    }

    public class Subscriber
    {

        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int[] magazineIds { get; set; }

    }

    public class SubscriberModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public List<Subscriber> data { get; set; }

    }

    public class CategoryModel
    {
        public bool succcess { get; set; }
        public string token { get; set; }
        public string[] data { get; set; }
    }

    public class Magazine
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }

    }

    public class MagazinesModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public List<Magazine> data { get; set; }

    }

    public class MagazineSubscriber
    {
        //public string id { get; set; }
        //public string firstName { get; set; }
        public string[] subscribers { get; set; }
    }




}
