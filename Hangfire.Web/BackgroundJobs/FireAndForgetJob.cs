﻿using Hangfire.Web.Services;

namespace Hangfire.Web.BackgroundJobs
{
    public class FireAndForgetJob
    {
        public static void EmailSendToUserJob(string userId,string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId,message));
        }


    }
}
