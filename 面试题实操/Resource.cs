using System;

namespace 面试题实操
{
    internal class Resource:IDisposable
    {
        private int v;

        public Resource(int v)
        {
            this.v = v;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void print()
        {
            throw new NotImplementedException();
        }
    }
}