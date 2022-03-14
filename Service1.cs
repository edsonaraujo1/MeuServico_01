using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace MeuServico_1
{
    public partial class Service1 : ServiceBase
    {
        Timer timer1;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(timer1_Tick), null, 15000, 60000);
        }

        protected override void OnStop()
        {
            StreamWriter vWriter = new StreamWriter(@"C:\LogRetorno\MeuServico\testeServico.txt", true);

            vWriter.WriteLine("Servico Parado: " + DateTime.Now.ToString());
            vWriter.Flush();
            vWriter.Close();
        }

        private void timer1_Tick(object sender)
        {
            StreamWriter vWriter = new StreamWriter(@"C:\LogRetorno\MeuServico\testeServico.txt", true);
            vWriter.WriteLine("Servico Rodando: " + DateTime.Now.ToString());
            vWriter.Flush();
            vWriter.Close();
        }
    }
}
