using System.Diagnostics;

namespace Hangfire.Web.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void WriteWatermarkStatusJıb(string jobId,string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(jobId,()=>Debug.WriteLine($"{fileName} : watermark eklenmiştir!"));
        }
    }
}
