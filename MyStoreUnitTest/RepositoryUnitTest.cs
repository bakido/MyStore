using System;
using System.Collections.Generic;
using System.Text;
using MyStore.Repository;
using  Xunit;
using MyStore.Data;
namespace MyStoreUnitTest
{
   public  class RepositoryUnitTest
    {

        [Theory]
        [InlineData(2,2,4)]
        private void TestTotalCostOfOrder(int a,int b, int results)
        {
            //Arrange
           // IUnitOfWork unit = new UnitOfWork();
            int sum = a + b;
            //Act

            //Assert
            Assert.Equal(sum, results);
        }
    }
}
