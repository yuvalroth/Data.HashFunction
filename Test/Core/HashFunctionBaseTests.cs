﻿using Moq;
using System;
using System.Collections.Generic;
using System.Data.HashFunction.Test.Mocks;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Data.HashFunction.Test.Core
{
    public class HashFunctionBaseTests
    {
        [Fact]
        public void HashFunctionBase_ComputeHash_Stream_NotReadable_Throws()
        {
            var msMock = new Mock<MemoryStream>();

            msMock.SetupGet(ms => ms.CanRead)
                .Returns(false);

            var hf = new HashFunctionImpl();

            Assert.Equal("data",
                Assert.Throws<ArgumentException>(() =>
                    hf.ComputeHash(msMock.Object))
                .ParamName);
        }
    }
}
