using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class HTMLDownload
    {
        public Task<string> GetHTML(int url)
        {
            return Task.Factory.StartNew(() =>
            {
                //var calculatingTime = new Random().Next(5000);
                //Thread.Sleep(calculatingTime);
                Thread.Sleep(5000);
                return $"html{url}";
            });
        }
    }
}