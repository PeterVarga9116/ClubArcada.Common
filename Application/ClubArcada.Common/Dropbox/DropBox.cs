using System;
using System.IO;
using System.Threading.Tasks;
using Dropbox;

namespace ClubArcada.Common.Dropbox
{
    public class Dropbox
    {
        private string Key = "q28bw3ocfdf91nr";
        private string Secret = "hqjqpxdse89gpvk";
        private string Token = "7uK1uVNNqpAAAAAAAAAAgKsWXBwJQz2x4XqrIEceNmOEJYzB8wy1ysu-DQpeCiyi";

        public async Task Upload(FileStream file, string path)
        {
            var client = new DropboxClient(Key, Secret);
            UploadFileRequest ufr = new UploadFileRequest(path);

            try
            {
                await client.UploadFile(new UploadFileRequest(path), file, Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Mailer.Mailer.SendErrorMail("Error - DropBox", ex.GetExceptionDetails());
            }
        }

        public async Task Upload(Stream file, string path)
        {
            var client = new DropboxClient(Key, Secret);
            UploadFileRequest ufr = new UploadFileRequest(path);

            try
            {
                await client.UploadFile(new UploadFileRequest(path), file, Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Mailer.Mailer.SendErrorMail("Error - DropBox", ex.GetExceptionDetails());
            }
        }

        public async Task Upload(MemoryStream file, string path)
        {
            var client = new DropboxClient(Key, Secret);

            try
            {
                await client.UploadFile(new UploadFileRequest(path), file, Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Mailer.Mailer.SendErrorMail("Error - DropBox", ex.GetExceptionDetails());
            }
        }
    }
}