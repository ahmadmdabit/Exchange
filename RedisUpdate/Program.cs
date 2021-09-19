using Common.Helpers;
using Entities;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisUpdate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("RedisUpdate Starting...");
            RedisHelper.DistributedCache = new RedisCache(new RedisCacheOptions { Configuration = "localhost:6379" });
            BackgroundThread();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void BackgroundThread()
        {
            new Thread(() =>
            {
                System.Timers.Timer timer = new System.Timers.Timer(250);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
                {
                    Console.WriteLine($"Data Updating... {DateTime.Now.Ticks}");
                    //File.AppendAllText(@"c:\temp\thread.txt", Environment.NewLine + DateTime.Now.ToString());

                    await UpdateRedisData();
                };
                timer.Start();
            }).Start();
        }

        private static async Task UpdateRedisData()
        {
            var dataList = await RedisHelper.GetRedisData<List<ExchangeInfo>>("dataList");
            if (dataList?.Count > 0)
            {
                dataList.ForEach(x =>
                {
                    if (new Random().Next() % 2 > 0)
                    {
                        x.PurchasePrice += x.StepSize;
                        x.SalePrice -= x.StepSize;
                    }
                    else
                    {
                        x.PurchasePrice -= x.StepSize;
                        x.SalePrice += x.StepSize;
                    }
                });
                await RedisHelper.SetRedisData("dataList", dataList);
            }
        }
    }
}