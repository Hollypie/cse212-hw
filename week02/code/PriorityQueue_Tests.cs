using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
        
    [TestMethod]
    // Scenario: Create a queue with the following items and priorities:  Elven Cloak (4), Lembas Bread (5), Palantir (6), Gollums Fish Snack (2), One Ring (8), Frodo's Journal (1), Gandalf's Hat (6),  Sting (7). Dequeue an item from the queue and see if the dequeued item is the item with the highest priority. 
    // Expected Result: "One Ring" should be the value returned when an item is dequeued from this queue
    // Defect(s) Found: No defect found.
    public void TestPriorityQueue_ItemsDequeuedInCorrectOrder()
    {
        var items = new PriorityQueue();
        items.Enqueue("Elven Cloak", 4);
        items.Enqueue("Lembas Bread", 5);
        items.Enqueue("Palantir", 6);
        items.Enqueue("Gollums Fish Snack", 2);
        items.Enqueue("One Ring", 8);
        items.Enqueue("Frodos Journal", 1);
        items.Enqueue("Gandalfs Hat", 6);
        items.Enqueue("Sting", 7);
        
        var item = items.Dequeue();

        Assert.AreEqual("One Ring", item, "Items are not dequeued in the correct order.");

    }

        
    [TestMethod]
    // Scenario: This test is to see if items with the same priority are dequeued with the first item added to the queue with the highest priority being dequeued. So I will add two items with the same priority and test which is being dequeued. Create a queue with the following items and priorities:  Elven Cloak (4), Lembas Bread (5), Palantir (6), Gollums Fish Snack (2), Frodo's Journal (1), Gandalf's Hat (6). Dequeue an item from the queue and see if the dequeued item is the item with the highest priority that was added first. 
    // Expected Result: "Palantir"
    // Defect(s) Found: No defect found.
    public void TestPriorityQueue_ItemsWithSamePriorityDequeuedInCorrectOrder()
    {
        var items = new PriorityQueue();
        items.Enqueue("Elven Cloak", 4);
        items.Enqueue("Lembas Bread", 5);
        items.Enqueue("Palantir", 6);
        items.Enqueue("Gollums Fish Snack", 2);
        items.Enqueue("Frodos Journal", 1);
        items.Enqueue("Gandalfs Hat", 6);
        
        
        var item = items.Dequeue();

        Assert.AreEqual("Palantir", item, "Items are not dequeued in the correct order.");

    }

    [TestMethod]
    // Scenario: Create a queue with the following items and priorities:  Elven Cloak (4), Lembas Bread (5), Palantir (6), Gollums Fish Snack (2), One Ring (8), Frodo's Journal (1), Gandalf's Hat (6),  Sting (7). Dequeue an item from the queue and Use an assert to verify that Dequeue removes an item from the queue. 
    // Expected Result: The length of the items queue should equal 7 since on should have been removed with the Dequeue method.
    // Defect(s) Found: When I ran the test the Result I got was 7 != 8; "The Dequeue method is not removing the dequeued item from the queue." I have gone into the dequeue method and added a line of code that removes the highest priority item when the dequeue method is ran. I also found that the loop in the dequeue started the index at 1 instead of 0. I corrected that as well.
    public void TestPriorityQueue_DoesDequeueRemoveItemDequeued()
    {
        var items = new PriorityQueue();
        items.Enqueue("Elven Cloak", 4);
        items.Enqueue("Lembas Bread", 5);
        items.Enqueue("Palantir", 6);
        items.Enqueue("Gollums Fish Snack", 2);
        items.Enqueue("One Ring", 8);
        items.Enqueue("Frodos Journal", 1);
        items.Enqueue("Gandalfs Hat", 6);
        items.Enqueue("Sting", 7);
        
        items.Dequeue();

        Assert.AreEqual(items.GetQueueSize(), 7, "The Dequeue method is not removing the dequeued item from the queue.");

    }

    [TestMethod]
    // Scenario: Test that the dequeue function throws an "InvalidOperationException("The queue is empty.");" when the queue is empty.
    // Expected Result: InvalidOperationException("The queue is empty.") message appears.
    // Defect(s) Found: No defect was found, it passed when I ran this test the first time. 
    public void TestPriorityQueue_IsQueueEmpty()
    {
        var queue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

    }

    [TestMethod]
    // Scenario: Create a queue with the following items and priorities:  Elven Cloak (6), Lembas Bread (5), Palantir (3), Gollums Fish Snack (2), One Ring (8), Frodo's Journal (1), Gandalf's Hat (4),  Sting (7), 
    // Verify that items are added to the queue in order. 
    // Expected Result: Elven Cloak, Lembas Bread, Palantir, Gollums Fish Snack, One Ring, Frodo's Journal, Gandalf's Hat, Sting
    // Defect(s) Found: I ran the test after writing the test and I got this error message. "Expected:<Sting>. Actual:<One Ring>. Items are not dequeued in the correct order."
    public void TestPriorityQueue_ItemsAreAddedToEndOfQueue()
    {
        var elven = new PriorityItem("Elven Cloak", 6);
        var lembas  = new PriorityItem("Lembas Bread", 5);
        var palantir  = new PriorityItem("Palantir", 4);
        var gollum = new PriorityItem("Gollums Fish Snack", 2);
        var ring = new PriorityItem("One Ring", 8);
        var frodo = new PriorityItem("Frodos Journal", 1);
        var gandalf = new PriorityItem("Gandalfs Hat", 4);
        var sting = new PriorityItem("Sting", 7);

        PriorityItem[] expectedResult =  {elven, lembas, palantir, gollum, ring, frodo, gandalf, sting};


        var items = new PriorityQueue();
        items.Enqueue("Elven Cloak", 6);

        var item = items.ReturnLast();

        Assert.AreEqual(item, expectedResult[0].Value, "Items are not added to the Queue in the correct order.");

        items.Enqueue("Lembas Bread", 5);
        items.Enqueue("Palantir", 4);
        items.Enqueue("Gollums Fish Snack", 2);

        var item2 = items.ReturnLast();

        Assert.AreEqual(item2, expectedResult[3].Value, "Items are not added to the Queue in the correct order.");

        items.Enqueue("One Ring", 8);
        items.Enqueue("Frodos Journal", 1);
        items.Enqueue("Gandalfs Hat", 4);
        items.Enqueue("Sting", 7);

        var item3 = items.ReturnLast();

        Assert.AreEqual(item3, expectedResult[7].Value, "Items are not added to the Queue in the correct order.");
    }

    [TestMethod]
    // Scenario: Verify that Enqueue is correctly storing the items value and it's priority. Add these items to the queue: "Elven Cloak", 4; "Lembas Bread", 5; "Palantir", 6; "Gollums Fish Snack", 2; "One Ring", 8; "Frodos Journal", 1; "Gandalfs Hat", 6; "Sting", 7; Then write Assert functions that test the value and the priority of the items in the queue. Do this at the beginning, somewhere in the middle and one at the end. 
    // Expected Result: The items added to the queue should return the correct value and priority. for example. When we Enqueue("Gollums Fish Snack", 2); to the queue, we should discover that the value stored is "Gollums Fish Snack" and the Priority is "2".
    // Defect(s) Found: No defect was found when I ran this test the first time. 
    public void TestPriorityQueue_EnqueueCorrectlyStoresValueandPriority()
    {
        var queue = new PriorityQueue();

        var items = new PriorityQueue();
        items.Enqueue("Elven Cloak", 4);
        var itemValue1 = items.ReturnLast();
        var itemPriority1 = items.ReturnPriority_Last();
        Assert.AreEqual(itemValue1, "Elven Cloak");
        Assert.AreEqual(itemPriority1, "4");

        items.Enqueue("Lembas Bread", 5);
        items.Enqueue("Palantir", 6);
        items.Enqueue("Gollums Fish Snack", 2);

        var itemValue2 = items.ReturnLast();
        var itemPriority2 = items.ReturnPriority_Last();
        Assert.AreEqual(itemValue2, "Gollums Fish Snack");
        Assert.AreEqual(itemPriority2, "2");

        items.Enqueue("One Ring", 8);
        items.Enqueue("Frodos Journal", 1);
        items.Enqueue("Gandalfs Hat", 6);
        items.Enqueue("Sting", 7);

        var itemValue3 = items.ReturnLast();
        var itemPriority3 = items.ReturnPriority_Last();

        Assert.AreEqual(itemValue3, "Sting");
        Assert.AreEqual(itemPriority3, "7");
    }

}