using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K42un0k0SnsDeck.Common
{
    class JobScheduler
    {
        private readonly Queue<ThreadStart> _taskQueue = new Queue<ThreadStart>();
        private Task _process;

        private async Task RunProcess()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (_taskQueue.Count <= 0)
                    {
                        break;
                    }
                    var task = _taskQueue.Dequeue();
                    task();
                }

            });
        }

        public void Enqueue(ThreadStart task)
        {
            _taskQueue.Enqueue(task);
            if (_process.IsCompleted) _process = RunProcess();
        }
    }
}
