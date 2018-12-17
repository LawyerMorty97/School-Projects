using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareDesignExam
{
    public class ProxyThread
    {
        private Thread[]    _threads;
        private int         _running = 0;

        public int Length
        {
            get { return _threads.Length; }
        }

        /// <summary>
        /// Creates an instance of ProxyThread
        /// </summary>
        /// <param name="threadCount">The amount of threads to create</param>
        public ProxyThread(int threadCount)
        {
            _threads = new Thread[threadCount];
        }

        /// <summary>
        /// Starts an additional thread and runs a specific method
        /// </summary>
        /// <param name="method">The method that the thread will run</param>
        public void StartAdditionalThread(Action method)
        {
            ThreadStart starter = new ThreadStart(method);
            Thread thread = new Thread(starter);

            thread.Start();

            int newIndex = Length + 1;

            // Create additional spaced arrays
            if (newIndex > _threads.Length)
            {
                Thread[] new_array = new Thread[_threads.Length + 2];
                for (int i = 0; i < _threads.Length; i++)
                {
                    new_array[i] = _threads[i];
                }
                _threads = new_array;
            }

            _threads[newIndex] = thread;
        }

        /// <summary>
        /// Creates all threads that were chosen and sets the method that will run on them
        /// </summary>
        /// <param name="method">The method that the thread will run</param>
        public void CreateThreads(Action method)
        {
            for (int i = 0; i < _threads.Length; i++)
            {
                ThreadStart starter = new ThreadStart(method);
                Thread thread = new Thread(starter);

                _threads[i] = thread;
            }
        }

        /// <summary>
        /// Start a thread individually. This can be used in a for-loop for example
        /// </summary>
        public void StartThread()
        {
            if (_running >= _threads.Length) return;
            Thread thread = _threads[_running];
            thread.Start();
            _running += 1;
        }

        /// <summary>
        /// Stops all threads
        /// </summary>
        public void StopThreads()
        {
            for (int i = 0; i < _threads.Length; i++)
            {
                Thread thread = _threads[i];

                if (thread != null && thread.IsAlive)
                    thread?.Join();
            }
        }
    }
}
