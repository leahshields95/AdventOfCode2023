using AdventOfCode2023.Day4;

namespace AdventOfCode2023.Test.Day4;

public class ScratchCardsTest
{
    
    [Test]
    public void ShouldGetTotalScratchCardsWhenOneCopyWon()
    {

        ScratchCard card1 = new ScratchCard(1,new List<int>(){1,2,3}, new List<int>(){1});
        ScratchCard card2 = new ScratchCard(2,new List<int>(){1,2,3}, new List<int>(){6});
        ScratchCards scratchCards = new ScratchCards(new List<ScratchCard>(){card1, card2});
      
        Assert.That(scratchCards.GetTotalScratchCardsAfterWinnings(), Is.EqualTo(3));
    }    
    
    [Test]
    public void ShouldGetTotalScratchCardsWhenMultipleCopiesWon()
    {

        ScratchCard card1 = new ScratchCard(1,new List<int>(){1,2,3}, new List<int>(){1,2,3});
        ScratchCard card2 = new ScratchCard(2,new List<int>(){1,2,3}, new List<int>(){1});
        ScratchCard card3 = new ScratchCard(3,new List<int>(){1,2,3}, new List<int>(){6});
        ScratchCard card4 = new ScratchCard(4,new List<int>(){1,2,3}, new List<int>(){6});
        ScratchCards scratchCards = new ScratchCards(new List<ScratchCard>(){card1, card2, card3, card4});
      
        Assert.That(scratchCards.GetTotalScratchCardsAfterWinnings(), Is.EqualTo(9));
    }

}