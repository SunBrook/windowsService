using DataDispose.Library.Models;
using DataDispose.Library.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataDispose.Library
{
    public class DisposeWork
    {
        public static bool IsMethodFinish = true;
        private static readonly object ObjectSync = new object();

        public static void Work1()
        {
            try
            {
                lock (ObjectSync)
                {
                    if (!IsMethodFinish)
                    {
                        LogHelper.Error("提示：上次方法没有执行完成。");
                        return;
                    }
                    IsMethodFinish = false;
                }

                List<MyTask> taskList;

                using (var db = new SqlserverContext())
                {
                    // 获取24小时内的任务数据，没有预期开始时间的不要
                    var oneDayBefore = DateTime.Now.Date.AddDays(-1).ToString("yyyyMMddHHmmss");
                    taskList = db.Tasks
                        .Where(c => c.StartTime.CompareTo(oneDayBefore) >= 0)
                        .ToList();

                    // 请求接口
                    var requestKey = AppSettings.GetValue<string>("RequestKey");
                    var url = AppSettings.GetValue<string>("RequestUrl");

                    var request = new ApiRequest
                    {
                        RequestKey = requestKey,
                        Tasks = taskList
                    };

                    // 请求接口，返回结果
                    var response = RequestUtils.Post<ApiRequest, ApiResult<ApiResponse>>(url, request, error =>
                    {
                        // 网络异常，记录错误信息
                        LogHelper.Error($"接口调用失败：{error}\n{JsonConvert.SerializeObject(request)}");
                    });

                    if (response != null)
                    {
                        if (response.Success)
                        {
                            // 接口调用成功
                            var partErrorIds = response.Data.ErrorIdList;
                            LogHelper.Info($"接口调用成功：\n{JsonConvert.SerializeObject(request)}");
                        }
                        else
                        {
                            // 接口处理异常
                            LogHelper.Error($"接口处理异常：{response.Message}\n{JsonConvert.SerializeObject(request)}");
                        }
                    }
                }

                // 写入本地
                using (var db = SqliteContext.Instance)
                {
                    db.LocalTasks.AddRange(taskList);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"程序异常：{ex}");
            }
            finally
            {
                IsMethodFinish = true;
            }
        }
    }
}
