using Unit8_SRP_F24;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24Tests
{
    [TestClass()]
    public class SimpleTradeParserTests
    {

        [TestMethod()]
        public void TestNumberOfPosLines()
        {
            //Arrange
            var validator = new PositiveTradeValidator();
            var mapper = new TradeMapper();
            var parser = new SimpleTradeParser(validator, mapper);
            List<string> sampleInput = new List<string> { "XXXYYY,1111,9.99", "XXXYYY,2222,9.99", "XXXYYY,3333,9.99" };

            //Act
            IEnumerable<TradeRecord> result = parser.ParseTrades(sampleInput);
            //Assert
            Assert.AreEqual(result.Count(), sampleInput.Count());
        }

        [TestMethod()]
        public void TestNumberOfNegLines()
        {
            //Arrange
            var validator = new NegativeTradeValidator();
            var mapper = new TradeMapper();
            var parser = new SimpleTradeParser(validator, mapper);
            List<string> sampleInput = new List<string> { "XXXYYY,1111,9.99", "XXXYYY,2222,9.99", "XXXYYY,3333,9.99" };

            //Act
            IEnumerable<TradeRecord> result = parser.ParseTrades(sampleInput);
            //Assert
            Assert.AreEqual(0, result.Count());
        }
    }


    public class PositiveTradeValidator : ITradeValidator
    {
        public bool ValidateTradeData(string[] tradeData, int currentLine)
        {
            return true;
        }
    }

    public class NegativeTradeValidator : ITradeValidator
    {
        public bool ValidateTradeData(string[] tradeData, int currentLine)
        {
            return false;
        }
    }

    public class TradeMapper : ITradeMapper
    {
        public TradeRecord MapTradeDataToTradeRecord(string[] fields)
        {
            TradeRecord sampleRec = new TradeRecord();
            sampleRec.DestinationCurrency = "XXX";
            sampleRec.SourceCurrency = "YYY";
            sampleRec.Price = 1.11M;
            sampleRec.Lots = 2.22F;
            return sampleRec;
        }
    }

}