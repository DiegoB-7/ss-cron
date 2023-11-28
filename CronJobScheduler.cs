using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ss_cron
{
    public class CronJobScheduler
    {
        public static async Task Start()
        {
            // Grab the Scheduler instance from the Factory
            IScheduler scheduler = await new StdSchedulerFactory().GetScheduler();

            // Define the job and tie it to our MyCronJob class
            IJobDetail job = JobBuilder.Create<CronJobGet>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithCronSchedule("0/10 * * * * ?") // Replace this with your cron expression
                .Build();

            // Define the job and tie it to our MyCronJob class
            IJobDetail job2 = JobBuilder.Create<CronJobPost>()
                .WithIdentity("myJob2", "group1")
                .Build();

            // Trigger the job to run now, and then every 10 seconds
            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("myTrigger2", "group1")
                .StartNow()
                .WithCronSchedule("0/10 * * * * ?") // Replace this with your cron expression
                .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);
            await scheduler.ScheduleJob(job2, trigger2);

            // Start the scheduler
            await scheduler.Start();
        }
    }
}
