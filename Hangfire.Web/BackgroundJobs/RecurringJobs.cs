using System.Diagnostics;

namespace Hangfire.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob_1",()=>EmailRapor(),Cron.Minutely);
        }
        public static void EmailRapor()
        {
            Debug.WriteLine("Rapor , email olarak gönderildi");
        }
    }
}
