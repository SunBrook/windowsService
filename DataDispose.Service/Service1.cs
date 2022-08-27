using DataDispose.Library;
using DataDispose.Library.Tools;
using System;
using System.ServiceProcess;
using System.Timers;

namespace DataDispose.Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            try
            {
                Timer workTimer = new Timer(60000)
                {
                    Enabled = true
                };
                workTimer.Elapsed += new ElapsedEventHandler(WorkTask);
                workTimer.Start();

            }
            catch (Exception exception)
            {
                LogHelper.Error(exception.ToString());
            }
        }

        private static bool IsFinish = true;

        private void WorkTask(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!IsFinish)
                {
                    LogHelper.Info("上次未执行完毕");
                    return;
                }
                IsFinish = false;

                // 添加任务
                Work1();

                // ...
                Work2();

                // ...
                Work3();
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{ex}");
            }
            finally
            {
                IsFinish = true;
            }
        }

        private void Work3()
        {
            // ...
        }

        private void Work2()
        {
            // ...
        }

        private void Work1()
        {
            try
            {
                LogHelper.Info($"添加任务开始执行,{DateTime.Now:yyyy-MM-dd HH:mm:ss}!!!");
                DisposeWork.Work1();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }
    }
}
