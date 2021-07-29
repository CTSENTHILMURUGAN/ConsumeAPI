using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsumeAPI
{
    public class Program
    {



        public static void Main(string[] args)
        {
            API obj = new API();
            CategoryModel _CategoryModel = new CategoryModel();
            SubscriberModel _SubscriberModel = new SubscriberModel();
            MagazinesModel _MagazinesModel = new MagazinesModel();
            MagazineSubscriber MagazineSubscriber = new MagazineSubscriber();
            MagazineSubscriber.subscribers = new string[] { };
            _CategoryModel = obj.GetCategory();
            _SubscriberModel = obj.GetSubscriber();
            
            for (int i = 0; i < _CategoryModel.data.Length; i++)
            {


                _MagazinesModel = obj.GetMagazine(_CategoryModel.data[i]);
                List<int> magazine = new List<int>();
                magazine = _MagazinesModel.data.Select(_ => _.id).ToList();
                string[] resultarr = _SubscriberModel.data.Where(_ => magazine.Any(x => _.magazineIds.Contains(x))).Select(_ => _.id).ToArray();

                MagazineSubscriber.subscribers= MagazineSubscriber.subscribers.Concat(resultarr).ToArray();
            }            

            obj.PostSubcribers(MagazineSubscriber);


        }
    }
}
