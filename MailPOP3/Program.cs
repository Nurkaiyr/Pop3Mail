using Limilabs.Client.POP3;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailPOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Pop3 pop3 = new Pop3())
            {              
                pop3.ConnectSSL("pop.mail.ru", 995);
                pop3.Login("pop3tester1@mail.ru", "Test12345");
                foreach (string uid in pop3.GetAll())
                {
                    IMail email = new MailBuilder()
                        .CreateFromEml(pop3.GetMessageByUID(uid));
                    Console.WriteLine(email.Subject);
                    Console.WriteLine(email.Text);

                    foreach (MimeData mime in email.NonVisuals)
            {
                mime.Save(@"d:\temp\" + mime.SafeFileName);
            }

                }
                pop3.Close(false);
                Console.ReadLine();
            }
        }
    }
}
