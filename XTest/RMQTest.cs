using HackerRank.Algorithm;
using System.Collections.Generic;
using Xunit;

namespace XTest
{
    public class RmqTest
    {
        [Fact]
        public void RMQ_SparseTable()
        {
            var list = new List<int> { 10, 1, 3, 9, 4, 8, 7 };
            var rmq = new RMQSparseTable(list);
            Assert.Equal(1, rmq.MinElem(0, 3));
            Assert.Equal(1, rmq.MinElem(1, 4));
            Assert.Equal(3, rmq.MinElem(2, 5));
        }
    }
}
