/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Sending an e-mail message.
*/

using System;
using Windows.ApplicationModel.Email;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnSendOneRecipient_Click(object sender, RoutedEventArgs e)
        {
            EmailMessage message = new EmailMessage();
            EmailRecipient recipient = new EmailRecipient("marcin@jamro.biz", "Marcin Jamro");
            message.To.Add(recipient);
            message.Body = "It is a message sent from a universal application.";
            message.Subject = "Subject of the message";
            await EmailManager.ShowComposeNewEmailAsync(message);
        }

        private async void BtnSendManyRecipients_Click(object sender, RoutedEventArgs e)
        {
            EmailMessage message = new EmailMessage();
            EmailRecipient recipientFirst = new EmailRecipient("marcin@jamro.biz", "Marcin Jamro");
            EmailRecipient recipientSecond = new EmailRecipient("marcin@tituto.com");
            message.To.Add(recipientFirst);
            message.To.Add(recipientSecond);

            EmailRecipient recipientCC = new EmailRecipient("copies@jamro.biz");
            message.CC.Add(recipientCC);

            EmailRecipient recipientBCC = new EmailRecipient("hidden@jamro.biz");
            message.Bcc.Add(recipientBCC);

            message.Body = "It is a message sent from a universal application to a few recipients.";
            message.Subject = "Subject of the message";
            message.Importance = EmailImportance.High;
            await EmailManager.ShowComposeNewEmailAsync(message);
        }

        private async void BtnSendWithAttachment_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                EmailMessage message = new EmailMessage();
                EmailRecipient recipient = new EmailRecipient("marcin@jamro.biz", "Marcin Jamro");
                message.To.Add(recipient);
                message.Body = "It is a message with an attachment, sent from a universal application.";
                message.Subject = "Subject of the message";

                RandomAccessStreamReference stream = RandomAccessStreamReference.CreateFromFile(file);
                EmailAttachment attachment = new EmailAttachment(file.Name, stream);
                message.Attachments.Add(attachment);
                await EmailManager.ShowComposeNewEmailAsync(message);
            }
        }
    }
}
