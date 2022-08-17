using Microsoft.AspNetCore.Components;

namespace BlazorAuth.Services;

using SendGrid;
using SendGrid.Helpers.Mail;

public class EmailService
{
    private const string EMAIL_FROM = "noreply@relationspaceonline.com.au";
    private const string FULLNAME_FROM = "Rental Ratings";

    public EmailService(ILogger<EmailService> logger)
    {
        Logger = logger;
    }

    public ILogger<EmailService> Logger { get; set; }
    
    
    public async Task<Response> SendEmail(string emailFrom, string fullnameFrom, string subject, string emailTo, string fullnameTo, string contentPlain, string contentHtml)
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(emailFrom, fullnameFrom);
        var to = new EmailAddress(emailTo, fullnameTo);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, contentPlain, contentHtml);
        
        Logger.LogInformation($@"Sending email with the following details: 
From: {fullnameFrom} <{emailFrom}>;
To: {fullnameTo} <{emailTo}>
Subject: {subject}
Content Plain:
--------------
{contentPlain}

Content HTML:
-------------
{contentHtml}
-- EOM --");
        
        return await client.SendEmailAsync(msg);
    }
    
    public async Task<Response>  SendResetEmail(string emailTo, string nameTo, string baseUrl, string activationKey)
    {
        var fullUrl = baseUrl + activationKey;
        var plainWelcome = $@"Dear {nameTo}
Someone (possibly you) has requested to reset the password for your Rental Ratings account. Follow the link below to reset your password:

{fullUrl}

If you did not request this reset, please contact our support staff immediately.

All the best,

The Rental Ratings Crew";
        
        var htmlWelcome = $@"Dear {nameTo},<br />
Someone (possibly you) has requested to reset the password for your Rental Ratings account. Follow the link below to reset your password:<br /><br />

<a href='{fullUrl}'>Link</a><br /><br />

If you did not request this reset, please contact our support staff immediately.<br /><br />

All the best,<br /><br />

The Rental Ratings Crew
";

        var subj = "Rental Ratings - reset account password";
        
        Logger.LogInformation($@"Sending password reset email to {nameTo} <{emailTo}>; subject = {subj}");

        return await SendEmail(EMAIL_FROM, FULLNAME_FROM, subj, emailTo, nameTo, plainWelcome, htmlWelcome);
    }
    
    
    public async Task<Response>  SendActivationEmail(string emailTo, string nameTo, string baseUrl, string activationKey)
    {
        var fullUrl = baseUrl + activationKey;
        // string subject = "Welcome to Rental Ratings!";
        var plainWelcome = $@"Dear {nameTo},
Welcome to Rental Ratings!
Please use the link below to activate your account and get started using our service.

{fullUrl}

All the best,

The Rental Ratings Crew";
        
        var htmlWelcome = $@"Dear {nameTo},<br />
Welcome to Rental Ratings!<br />
Please use the link below to activate your account and get started using our service.<br /><br />

<a href='{fullUrl}'>Link</a><br /><br />

All the best,<br />

The Rental Ratings Crew";

        var subj = "Rental Ratings - account activation link";
        
        Logger.LogInformation($@"Sending activation email to {nameTo} <{emailTo}>; subject = {subj}");

        return await SendEmail(EMAIL_FROM, FULLNAME_FROM, subj, emailTo, nameTo, plainWelcome, htmlWelcome);

    }
}